using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    private TextMeshPro numberText;
    private int hitNumber ;
    public PopupValue popupValue;
    public Ball randomBallPrefab;
    //public ScoreUpdate score;
    public List<Color> listColor = new List<Color>();
    public delegate void RemoveBall(Block block);
    public static event RemoveBall RemoveBallFromlist;
    public  delegate void AddNewBalls();
    public static event AddNewBalls AddNewBallsToList;
    private Vector3 origSize, bounceSize;
    private void Awake()
    {
        numberText = GetComponentInChildren<TextMeshPro>();
    }

    private void Start()
    {
        origSize = new Vector3(2f, 2f, 7.06149f);
        bounceSize = new Vector3(2.5f, 1.8f, 7.06149f);
        //rb = GetComponent<Rigidbody>();
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
