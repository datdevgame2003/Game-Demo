using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public HealthBar healthBar;
  
    public float presentHealth = 0; 
    public float maxHealth = 10;
    public Transform player;  
    public float moveSpeed = 2.5f;
    public float attackRange = 0.5f;
    private Vector2 movement;

    private Rigidbody2D rb;
    [SerializeField]
    GameObject ExplosionPrefab, HitEffectPrefab;
    private CollsionHandling playerCollision;
    void Start()
    {
        presentHealth = maxHealth;
        healthBar.HealthBarUpdate(presentHealth, maxHealth);
        rb = GetComponent<Rigidbody2D>();
        playerCollision = player.GetComponent<CollsionHandling>();
    }
    void Update()
    {
      
        if (playerCollision != null && playerCollision.isAlive)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            movement = direction;
        }
        else
        {
            movement = Vector2.zero;
        }
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.tag.Equals("bullet") && presentHealth > 0)
        {
            Instantiate(HitEffectPrefab, transform.position, Quaternion.identity);
            presentHealth--;
            healthBar.HealthBarUpdate(presentHealth, maxHealth);
            Destroy(other.gameObject);
            if (other.gameObject.tag.Equals("bullet") && presentHealth <= 0)
            {
                Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
                Debug.Log("Destroy");
                Destroy(gameObject);
               
                
            }
        }

    }
    private void FixedUpdate()
    {
        if (playerCollision != null && playerCollision.isAlive)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);


            if (distanceToPlayer > attackRange)
            {
                MoveTowardsPlayer(movement);
            }
            else
            {
                StopChasingPlayer();
            }
        }
        else
        {
            StopChasingPlayer();
        }
    }
        void MoveTowardsPlayer(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
    }

    void StopChasingPlayer()
    {
        
        rb.velocity = Vector2.zero; 
    }




}
