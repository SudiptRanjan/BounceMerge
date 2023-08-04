using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    private TextMeshPro numberText;
    private int hitNumber ;
    public PopupValue popupValue;
    private Rigidbody rb;
    public Ball randomBallPrefab;
    public Transform pre;
    //int score = 0;
    public List<Color> listColor = new List<Color>();
    public delegate void RemoveBall(Block block);
    public static event RemoveBall RemoveBallFromlist;
    public  delegate void AddNewBalls();
    public static event AddNewBalls AddNewBallsToList;
    private void Awake()
    {
        numberText = GetComponentInChildren<TextMeshPro>();
    }

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    public void SetBlockNo(int hits)
    {
        hitNumber = hits;
        UpdateTheText();
    }
    

    void UpdateTheText()

    {
        numberText.SetText(hitNumber.ToString());
        //numberText.SetText(ballNoInTextPopup.ToString());
    }

   

    void SpawnRandomBalls()
    {
        if (Random.Range(1, 100) > 20)
        {
            Ball initialBall = Instantiate(randomBallPrefab, transform.position, Quaternion.identity);
            initialBall.GetComponent<MeshRenderer>().material.color = listColor[Random.Range(0, listColor.Count)];

            AddNewBallsToList();
        }
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball!= null)
        {
            hitNumber -= ball.ballNo;
            popupValue.SpawnValue(transform.position, ball.ballNo);

            //ballNoInTextPopup = ball.ballNo;
            //Debug.Log("block value===" + ballNoInTextPopup);
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
