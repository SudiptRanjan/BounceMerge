
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public List<Ball> BalList;
    public Transform firingPoint;
    public BallsCollection ballsCollection;
    public bool shoot = false;
    public int ballCount;
    private void Start()
    {


    }
    private void OnEnable()
    {
        PlayerInput.OnClick += RotateTheBallLauncher;
        PlayerInput.OnClickUp += LaunchBalls;
    }
    private void OnDisable()
    {
        PlayerInput.OnClick -= RotateTheBallLauncher;
        PlayerInput.OnClickUp -= LaunchBalls;
    }

    private void RotateTheBallLauncher()
    {
        shoot = true;
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
         ballCount = BalList.Count;
        BalList.Clear();

        for (int i = 0; i <ballCount; i++)
        {
            newBalList[i].Shoot(firingPoint, -transform.up);
            await Task.Delay(150);

        }

    }
    public void BallsWhenFired()
    {
        List<Ball> firedBalls = new List<Ball>();
        firedBalls.AddRange(BalList);

    }
    public void StoreBall(Ball ball)
    {
        BalList.Add(ball);

    }

}
