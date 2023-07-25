using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsCollection : MonoBehaviour
{
    public List<Transform> pointList;
    public Ball ballPrefab;
    public BallLauncher ballLauncher;
    public int noOFBalls = 2;

    private void Start()
    {
        for(int i = 0;i< noOFBalls; i++)
        {
            Ball initialBall = Instantiate(ballPrefab);
            initialBall.MakeBodystatic();
            ballLauncher.StoreBall(initialBall);
            int indexStart = ballLauncher.BalList.Count - 1;

            initialBall.transform.position = pointList[indexStart].transform.position;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        Ball ball = collision.gameObject.GetComponent<Ball>();
        ball.MakeBodystatic();
        ballLauncher.StoreBall(ball);
        int index = ballLauncher.BalList.Count - 1;
            ball.transform.position = pointList[index].transform.position;

    }
}
