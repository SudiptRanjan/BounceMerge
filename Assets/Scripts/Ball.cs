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
    int randomNumber;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballValue = GetComponentInChildren<TextMeshPro>();
        randomNumber = (int)Mathf.Pow(2, Random.Range(1, 5));
        SetTheNumber(randomNumber);
    }

    public void UpdateText()
    {
        ballValue.SetText(ballNo.ToString());

    }
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
}
