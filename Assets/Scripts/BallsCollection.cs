//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsCollection : MonoBehaviour
{
    public List<Transform> pointList;
    public Ball ballPrefab;
    public BallLauncher ballLauncher;
    public int numberOfBalls = 2;
    public List<Color> coloredBalls = new List<Color>();
    public delegate void SpawningOfBlocks();
    public static event SpawningOfBlocks BlocksSpawn;

    public delegate void MergingOfBalls();
    public static event MergingOfBalls MergingOfBall ;

    private void Start()
    {
        //for (int i = 0; i < numberOfBalls; i++)
        //{
        //    Ball initialBall = Instantiate(ballPrefab);
        //    initialBall.GetComponent<MeshRenderer>().material.color = coloredBalls[Random.Range(0, coloredBalls.Count)];
        //    initialBall.MakeBodystatic();
        //    ballLauncher.StoreBall(initialBall);
        //    initialBall.transform.position = pointList[i].transform.position;
        //}
    }

    public void InstantiateBalls()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            Ball initialBall = Instantiate(ballPrefab);
            initialBall.GetComponent<MeshRenderer>().material.color = coloredBalls[Random.Range(0, coloredBalls.Count)];
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
        int indexOfPoints = pointList.Count -1;

        //Debug.Log(indexOfPoints);
        if(index <= indexOfPoints)
        {
            ball.transform.position = pointList[index].transform.position;

        }
        else
        {
            ball.transform.position= pointList[indexOfPoints].transform.position;
            //Debug.Log("stored in the last position");
        }
        //ball.transform.position = pointList[index].transform.position;

        if (BlocksSpawn != null)
        {
            if (ballLauncher.ballCount == ballLauncher.BalList.Count)
            {
                //Debug.Log("The count did not matched ");

                //ballLauncher.MergeBalls();
                if (MergingOfBall != null)
                {
                    MergingOfBall();
                    Time.timeScale = 1F;
                    //gameObject.GetComponent<PlayerInput>().enabled = false;

                }


                BlocksSpawn();
            }
           
        }
    }



}
