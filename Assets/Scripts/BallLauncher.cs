
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
    public delegate void ControlInput();

    private void OnEnable()
    {
        PlayerInput.OnClick += RotateTheBallLauncher;
        PlayerInput.OnClickUp += LaunchBalls;
        Block.AddNewBallsToList += IncreaseBallCount;
        //BallsCollection.BallLauncher += LaunchBalls;
        //BallsCollection.Stoprotaing += RotateTheBallLauncher;
    }

    private void OnDisable()
    {
        PlayerInput.OnClick -= RotateTheBallLauncher;
        PlayerInput.OnClickUp -= LaunchBalls;
        Block.AddNewBallsToList += IncreaseBallCount;

        //BallsCollection.BallLauncher -= LaunchBalls;
        //BallsCollection.Stoprotaing -= RotateTheBallLauncher;

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
        playerInput.shoot = true;
    }
    public void IncreaseBallCount()
    {
        ballCount++;
    }
    public void StoreBall(Ball ball)
    {
        BalList.Add(ball);

    }
    
}
