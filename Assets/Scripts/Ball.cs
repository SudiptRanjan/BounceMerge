using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    private float power = 20;
    private TextMeshPro ballValue;
    public int ballNo ;
    public Rigidbody rb;
    private Vector3 direction;
    private float force;
    private SphereCollider sphereCollider;
    int randomNumber;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //direction = new Vector3(Random.value, Random.value, 0);
        ballValue = GetComponentInChildren<TextMeshPro>();
        randomNumber = (int)Mathf.Pow(2, Random.Range(1, 5));
        SetTheNumber(randomNumber);
        sphereCollider = GetComponent<SphereCollider>();
    }

    public void UpdateText()
    {
        ballValue.SetText(ballNo.ToString());

    }
    //void FixedUpdate()
    //{
    //    force = (float)Random.Range(-10, 10);
    //    direction = new Vector3(Random.Range(0, 10), Random.value, 0);
    //    rb.AddForce(direction * force);
    //    Debug.Log("direction" + direction);
    //    Debug.Log("direction" + force);
    //}


    private void SetTheNumber(int number)
    {
        ballNo = number;
        ballValue.text = number.ToString();
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

    private void OnCollisionEnter(Collision collision)
    {
        //direction = new Vector3(Random.value, Random.value, 0);
        direction = new Vector3(Random.Range(1,50 ), Random.Range(0, 1), 0);

        force = (float)Random.Range(-20, 20);
        rb.AddForce(direction * force);
        //Debug.Log("direction" + direction);
        //Debug.Log("force" + force);
        //float bouncevalue = sphereCollider.material.bounciness;
        //bouncevalue = bouncevalue - 0.5f;
        //Debug.Log(bouncevalue);
    }
}
