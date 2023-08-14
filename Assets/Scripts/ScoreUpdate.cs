using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{

    public TextMeshProUGUI myScoreText;
    public static ScoreUpdate instance;
    int score;

    public void Start()
    {
        instance = this;
        score = 0;
        myScoreText.text = score.ToString();

    }
    public void Update()
    {
        myScoreText.text = "Score :" + score;
    }

    public void AddScore(int udscore)
    {
        score = score + udscore;
        HighScore.instance.UpdateHighScore(score);
    }


    public void ScoreWhenGameOver()
    {
        score = 0 ;
    }
}