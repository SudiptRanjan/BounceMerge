using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float power = 16;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Shoot(Transform firePoint,Vector3 dir)
    {
        transform.position = firePoint.transform.position;
        rb.velocity = dir * power;
        rb.isKinematic = false;
        rb.useGravity = true;
    }
  
    public void MakeBodystatic()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
    }
}
