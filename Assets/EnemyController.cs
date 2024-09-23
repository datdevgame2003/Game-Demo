using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public HealthBar healthBar;
    public float presentHealth = 0; 
    public float maxHealth = 3;
    [SerializeField]
    GameObject ExplosionPrefab, HitEffectPrefab;
    void Start()
    {
        presentHealth = maxHealth;
        healthBar.HealthBarUpdate(presentHealth, maxHealth);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.tag.Equals("bullet") && presentHealth > 0)
        {
            Instantiate(HitEffectPrefab, transform.position, Quaternion.identity);
            presentHealth--;
            healthBar.HealthBarUpdate(presentHealth, maxHealth);
            if (other.gameObject.tag.Equals("bullet") && presentHealth <= 0)
            {
                Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
                Debug.Log("Destroy");
                Destroy(other.gameObject);
                Destroy(gameObject);
                
            }
        }


    }
   
   


}
