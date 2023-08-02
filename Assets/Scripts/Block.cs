using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{

    private TextMeshPro numberText;
    public int hitNumber =7;
    public Rigidbody rb;
    public delegate void RemoveBall(Block block);
    public static event RemoveBall RemoveBallFromlist;
    public Ball randomBallPrefab;
    public  delegate void AddNewBalls();
    public static event AddNewBalls AddNewBallsToList;

    private void Awake()
    {
        numberText = GetComponentInChildren<TextMeshPro>();
        //UpdateTheText();
        //numberText.SetText(hitNumber.ToString());
    }
   
    // Update is called once per frame
    public void SetBlockNo(int hits)
    {
        hitNumber = hits;
        UpdateTheText();
    }
    void UpdateTheText()

    {
        numberText.SetText(hitNumber.ToString());

    }
     void  SpawnRandomBalls()
    {
        if (Random.Range(1, 100) > 70)
        {
            Ball initialBall = Instantiate(randomBallPrefab, transform.position, Quaternion.identity);
            AddNewBallsToList();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if(ball!= null)
        {
            hitNumber -= ball.ballNo;
            //Debug.Log("ball value===" + ball.ballNo);
            //hitNumber--;
            if (hitNumber > 0)
            {
                UpdateTheText();
            }
            else
            {
                RemoveBallFromlist(this);
                Destroy(gameObject);
                SpawnRandomBalls();

            }
        }
       
    }
}
