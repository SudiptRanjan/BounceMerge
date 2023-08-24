using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    private TextMeshPro numberText;
    private int hitNumber ;
    private int newNumber;
    public PopupValue popupValue;
    public Ball randomBallPrefab;
    //public ScoreUpdate score;
    public List<Color> listColor = new List<Color>();
    public delegate void RemoveBall(Block block);
    public static event RemoveBall RemoveBallFromlist;
    public  delegate void AddNewBalls();
    public static event AddNewBalls AddNewBallsToList;
    private Vector3 origSize, bounceSize;
    int minValue = 100;
    int initial =1;
    int final = 5;
    int randomNumber;

    private void Awake()
    {
        numberText = GetComponentInChildren<TextMeshPro>();
    }

    private void Start()
    {
        origSize = new Vector3(2f, 2f, 7.06149f);
        bounceSize = new Vector3(1.5f, 1.5f, 7.06149f);
        //rb = GetComponent<Rigidbody>();
        newNumber = hitNumber;
    }

    private void Update()
    {
        //if (hitNumber >minValue)
        //{
        //    randomBallPrefab.IncreaseBallNo();
        //    minValue += 100;
            
        //}
    }
    public void SetBlockNo(int hits)
    {
        hitNumber = hits;
        UpdateTheText();
        //Debug.Log("The Value of blocks===" + hitNumber);

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
            //randomNumber = (int)Mathf.Pow(2, Random.Range(initial, final));
            //randomBallPrefab.SetTheNumber(randomNumber);
            Debug.Log("the Value of blocks" + hitNumber);
            //if (newNumber > minValue)
            //{
            //    //initial++;
            //    //final++;
            //    randomBallPrefab.IncreaseBallNo();
            //    minValue = 100;
            //    Debug.Log("the value balls increases =" + initial);
            //    Debug.Log("the value balls increases =" + final);

            //}
                AddNewBallsToList();
        }

       
     
    }
    //public void UpdateText()
    //{
    //    ballValue.SetText(ballNo.ToString());

    //}
    //private void SetTheNumber(int number)
    //{
    //    ballNo = number;
    //    ballValue.text = number.ToString();
    //}

    private void OnScale()
    {
        var tween = transform.DOScale(bounceSize, 0.09f).OnComplete(() => { transform.DOScale(origSize, 0.09f); });
        if (tween.IsPlaying()) return;

    }



    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        AudioManager.instance.PlaySound(AudioManager.SoundName.BounceBall);
        ExplosionPowerUp explosionPowerUp = collision.gameObject.GetComponent<ExplosionPowerUp>();
        OnScale();
        if (explosionPowerUp != null)
        {
            Destroy(this);
        }

        if (ball!= null)
        {
            hitNumber -= ball.ballNo;
            //score.AddScore(ball.ballNo);
            ScoreUpdate.instance.AddScore(ball.ballNo);
            popupValue.SpawnValue(transform.position, ball.ballNo);

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
