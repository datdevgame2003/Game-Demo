using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    Transform gunTransform;
    [SerializeField]
    GameObject bulletPrefab;
   
    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;
    public Button upButton;
    public Button downButton;   

    public float smoothTime = 0.1f;
    private Vector2 currentVelocity = Vector2.zero;

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

    public bool isMovingLeft = false;
    public bool isMovingRight = false;
    public bool jumpPressed = false;

    private bool isMovingUp = false;
    private bool isMovingDown = false;

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

        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
        jumpButton.onClick.AddListener(Jump);
        upButton.onClick.AddListener(MoveUp);
        downButton.onClick.AddListener(MoveDown);


        jumpButton.onClick.AddListener(Jump);
    }

   
    
public void MoveLeft()
{
    left_right = -1;

}
    public void StopMoveLeft()
    {
        left_right = 0;
    }

public void MoveRight()
{
    left_right = 1;

}
public void StopMoveRight()
{
  left_right = 0;

}
    public void Jump()
    {
        if (allowJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, height);
            allowJump = false;
        }
    }
    public void MoveUp()
    {
        isMovingUp = true;
        isMovingDown = false;
    }
    public void StopMoveUp()
    {
        isMovingUp = false;
    }

    public void MoveDown()
    {
        isMovingDown = true;
        isMovingUp = false;
    }
    public void StopMoveDown()
    {
        isMovingDown = false;
        
    }

    void StopClimb()
    {
        isMovingUp = false;
        isMovingDown = false;
    }


    void Update()
    {
        
        //move
        Vector2 targetVelocity = new Vector2(left_right * speed, rb.velocity.y);
     
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref currentVelocity, smoothTime);
        flip();

        //anim
        if (Mathf.Abs(left_right) > 0)
        {
            anim.SetFloat("move", Mathf.Abs(left_right));
        }
        else
        {
            anim.SetFloat("move", 0);
        }
      
        if (!Input.GetMouseButton(0))
        {
            left_right = 0;
        }
           
    }

    private void OnTriggerEnter2D(Collider2D collision) //ortherhitboxes
    {
        if (collision.gameObject.tag == "floor")
        {
            allowJump = true;
        }
        
           

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
            StopClimb();
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
            float climbInput = 0;
            if (isMovingUp)
            {
                climbInput = 1; 
            }
            else if (isMovingDown)
            {
                climbInput = -1; 
            }
            rb.velocity = new Vector2(rb.velocity.x, climbInput * climbSpeed);
        }
    }
    public void Fire()
    {
        Debug.Log("create bullet");
        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, Quaternion.identity);
        shootingSound.clip = listAudios[0];
        shootingSound.Play();
        bullet.GetComponent<BulletController>().SetDirection(isFacingRight ? Vector2.right : Vector2.left);
        Destroy(bullet, 2f);
    }




}
