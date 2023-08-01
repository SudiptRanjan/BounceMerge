
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public List<Ball> BalList;
    public Transform firingPoint;
    public int ballCount;
    public PlayerInput playerInput;
    public BallsCollection ballsCollection;

    private void OnEnable()
    {
        PlayerInput.OnClick += RotateTheBallLauncher;
        PlayerInput.OnClickUp += LaunchBalls;
        Block.AddNewBallsToList += IncreaseBallCount;
      
    }

    private void OnDisable()
    {
        PlayerInput.OnClick -= RotateTheBallLauncher;
        PlayerInput.OnClickUp -= LaunchBalls;
        Block.AddNewBallsToList += IncreaseBallCount;
    }
   

    private void RotateTheBallLauncher()
    {
        Vector3 mousPosition = Input.mousePosition;
        mousPosition.z = Camera.main.transform.position.z;
        Vector3 InputMousePosition = Camera.main.ScreenToWorldPoint( mousPosition);
        Vector3 direction = transform.position - InputMousePosition;
        Quaternion rotation = Quaternion.LookRotation( Vector3.forward,direction);
        transform.rotation = rotation;
    }

    public async void  LaunchBalls()
    {
        List<Ball> newBalList = new List<Ball>();
        newBalList.AddRange(BalList);
        IncreaseBallCount();
         ballCount = BalList.Count;
        BalList.Clear();
        for (int i = 0; i < newBalList.Count; i++)
        {
            newBalList[i].Shoot(firingPoint, -transform.up);
            await Task.Delay(150);
        }
      
        gameObject.GetComponent<PlayerInput>().enabled = false;

    }
    public void IncreaseBallCount()
    {
        ballCount++;
    }
    public void StoreBall(Ball ball)
    {
        BalList.Add(ball);

    }
    public void MergeBalls()
    {
        for (int i = ballCount - 1; i > 0; i--)
        {

            if (BalList[i - 1].ballNo == BalList[i].ballNo)
            {

                BalList[i].ballNo *= 2;
                BalList[i].UpdateText();
                Ball ball = BalList[i - 1];
                BalList.Remove(ball);
                Destroy(ball.gameObject);
            }
            ballCount--;

        }
        List<Ball> MergedBallsList = new List<Ball>();
        MergedBallsList.AddRange(BalList);
        for(int j = 0; j< MergedBallsList.Count;j++)
        {
            MergedBallsList[j].transform.position = ballsCollection.pointList[j].transform.position;
        }
        


    }

}
