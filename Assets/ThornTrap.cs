using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornTrap : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private bool isFalling = false;
    public Transform restorePoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter");
       
        if (collision.CompareTag("Player") && !isFalling)
        {
            rb.isKinematic = false;
            isFalling = true;
            Invoke("RestoreThorn", 2f);
        }

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.)
    //}

    private void RestoreThorn()
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.angularDrag = 0;
        transform.position = restorePoint.position;
        isFalling = false;
    }



}
