using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CollsionHandling : MonoBehaviour
{
    public GameObject gameoverOj;
    public GameObject gamewinOj;
    public int coin = 0;
    public int health;
    public bool isAlive = true;
    public TextMeshProUGUI starcoinText;
    public TextMeshProUGUI healthText;
    [SerializeField]
    GameObject ExplosionPrefab, HitEffectPrefab;
    AudioSource coinSound;

    [SerializeField]
    List<AudioClip> listAudios;
    // Start is called before the first frame update
    void Start()
    {
        starcoinText.SetText(coin.ToString());
        healthText.SetText(health.ToString());
        coinSound = GetComponent<AudioSource>();

    }

  
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coin++;
            coinSound.clip = listAudios[0];
            coinSound.Play();
            starcoinText.SetText(coin.ToString());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("health"))
        {
            health++;
            coinSound.clip = listAudios[0];
            coinSound.Play();
            healthText.SetText(health.ToString());
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("bullet") && health > 0)
        {
            Instantiate(HitEffectPrefab, transform.position, Quaternion.identity);
            health--;
            healthText.SetText(health.ToString());
            if (health == 0)
            {
                isAlive = false;
                gameoverOj.SetActive(true);
                Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }
        if (collision.CompareTag("win"))
        {
           
            gamewinOj.SetActive(true);
            
        }
    }  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Instantiate(HitEffectPrefab, transform.position, Quaternion.identity);
            health--;
            healthText.SetText(health.ToString());
            if (health == 0)
            {
                Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
                isAlive = false;
                Destroy(gameObject);
                gameoverOj.SetActive(true);
            }
        }
    }
}
