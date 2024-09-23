using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirleTrap : MonoBehaviour
{
    public float rotationSpeed = 3f;
    public float moveSpeed = 3.5f;
    public Transform pointA;
    public Transform pointB;
    public Vector3 targetPoint;
    void Start()
    {
        targetPoint = pointA.position;
    }

   
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position,targetPoint) < 0.1f)
        {
            if(transform.position == pointA.position)
            {
                targetPoint = pointB.position;
            }
            else
            {
                targetPoint = pointA.position;
            }
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
}
