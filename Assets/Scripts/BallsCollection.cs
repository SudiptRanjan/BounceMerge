using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsCollection : MonoBehaviour
{
    public List<Transform> pointList;
    public Ball ballPrefab;
    public BallLauncher ballLauncher;
    public int numberOfBalls = 2;

    public delegate void SpawningOfBlocks();
    public static event SpawningOfBlocks BlocksSpawn;

    public delegate void MergingOfBalls();
    public static event MergingOfBalls MergingOfBall ;

    private void Start()
    {
        for(int i = 0;i< numberOfBalls; i++)
        {
            Ball initialBall = Instantiate(ballPrefab);
            initialBall.MakeBodystatic();
            ballLauncher.StoreBall(initialBall);
            initialBall.transform.position = pointList[i].transform.position;

        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        Ball ball = collision.gameObject.GetComponent<Ball>();
        ball.MakeBodystatic();
        ballLauncher.StoreBall(ball);
        int index = ballLauncher.BalList.Count - 1;
        ball.transform.position = pointList[index].transform.position;

        if (BlocksSpawn != null)
        {
            if (ballLauncher.ballCount == ballLauncher.BalList.Count)
            {
                //ballLauncher.MergeBalls();
                if(MergingOfBall != null)
                {
                    MergingOfBall();
                }

                ballLauncher.GetComponent<PlayerInput>().enabled = true;

                BlocksSpawn();
            }
        }
    }



}
