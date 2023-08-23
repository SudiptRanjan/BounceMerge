using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public int ballNo;
    public Rigidbody rb;

    private float power = 50;
    private TextMeshPro ballValue;
    private Vector3 direction;
    private float force;
    private SphereCollider sphereCollider;
    int randomNumber;
    private Vector3 origSize, bounceSize;
    int multiple,initial,final;

    void Start()
    {
        initial = 1;
        final = 5;
        rb = GetComponent<Rigidbody>();
        //direction = new Vector3(Random.value, Random.value, 0);
        ballValue = GetComponentInChildren<TextMeshPro>();
        randomNumber = (int)Mathf.Pow(2, Random.Range(initial * multiple, final * multiple));
        SetTheNumber(randomNumber);
        sphereCollider = GetComponent<SphereCollider>();
        origSize = new Vector3(2, 2, 2);
        bounceSize = new Vector3(1.4f, 0.7f, 2);
        multiple++;
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

    public void Shoot(Transform firePoint, Vector3 dir)
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

    private void SetTheNumber(int number)
    {
        ballNo = number;
        ballValue.text = number.ToString();
    }

    public void OnScale()
    {
       var tween = transform.DOScale(bounceSize, 0.09f).OnComplete(() => { transform.DOScale(origSize, 0.09f); });
        if (tween.IsPlaying()) return;
        Debug.Log("compressed");
    }



    private void OnCollisionEnter(Collision collision)
    {
        //direction = new Vector3(Random.value, Random.value, 0);
        direction = new Vector3(Random.Range(1,50 ), Random.Range(0, 100), 0);

        force = (float)Random.Range(-20, 20);
        rb.AddForce(direction * force);
        OnScale();

        //Debug.Log("direction" + direction);
        //Debug.Log("force" + force);
        //float bouncevalue = sphereCollider.material.bounciness;
        //bouncevalue = bouncevalue - 0.5f;
        //Debug.Log(bouncevalue);
    }
}
//transform.DOKill();
//transform.DOScale(bounceSize, 1f).SetEase(Ease.OutSine).OnComplete(() => { transform.DOScale(origSize, 1f).SetEase(Ease.OutSine).SetDelay(1).OnComplete(OnScale); });
