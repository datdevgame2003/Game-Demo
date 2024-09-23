using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    Transform gunTransform;
    [SerializeField]
    GameObject bulletPrefab;
    //[SerializeField]
    //GameObject ExplosionPrefab, HitEffectPrefab;

   
    //public int coin = 0;
    
    public bool isFacingRight = true;
    public float left_right;
    public float speed;
    public float height;
    private Rigidbody2D rb;
    private Animator anim;
    public bool allowJump;
    public bool doubleJump;
   
    public float climbSpeed = 3f;
    private bool isClimbing = false;
    //private bool canTakeDamage = true;
    //private bool canCollectCoin = true;
    [SerializeField]
    //private float invulnerabilityTime = 0.5f;
    //public float minX = -28.6f;
    //public float maxX = 54.1f;

    AudioSource shootingSound;
    
   
    [SerializeField]
    List<AudioClip> listAudios;
    void Start()
    {
        

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        shootingSound = GetComponent<AudioSource>();
       
      
    }

    
    void Update()
    {
        //float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        //transform.position = new Vector2(clampedX, transform.position.y);

        left_right = Input.GetAxisRaw("Horizontal");
        //move
        rb.velocity = new Vector2(left_right * speed, rb.velocity.y); 
        flip();
        //anim
        anim.SetFloat("move", Mathf.Abs(left_right));
       

        if (allowJump && !Input.GetKey(KeyCode.Space))
        {

            doubleJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (allowJump || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, height);
                doubleJump = !doubleJump;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("create bullet");
            GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, Quaternion.identity);
            shootingSound.clip = listAudios[0];
            shootingSound.Play();
            bullet.GetComponent<BulletController>().SetDirection(isFacingRight ? Vector2.right : Vector2.left);
            bulletPrefab.SetActive(true);
            Destroy(bullet, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //ortherhitboxes
    {
        if (collision.gameObject.tag == "floor")
        {
            allowJump = true;
        }
        //if (collision.CompareTag("bullet") && canTakeDamage)
        //{
        //    TakeDamage();
           
        //}
            //if (collision.CompareTag("Coin") && canCollectCoin)
            //{
            //CollectCoin(collision.gameObject);
            
            //coinSound.clip = listAudios[1];
            //coinSound.Play();
            
        //}

            if(collision.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.gravityScale = 0f;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            allowJump = false;
        }
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.gravityScale = 1f;
        }
    }
     void flip()
    {
        if (isFacingRight && left_right < 0 || !isFacingRight && left_right > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 size = transform.localScale;
            size.x = size.x * -1;
            transform.localScale = size;
        }
    }
   
   
    private void FixedUpdate()
    {
        if(isClimbing)
        {
            float climbInput = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, climbInput * climbSpeed);
        }
    }




}
