
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public List<Ball> BalList;
    public Transform firingPoint;
    public bool shoot = false;

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
        int ballCount = BalList.Count;
        for (int i = 0;i< ballCount; i++)
        {
          
            BalList[i].Shoot(firingPoint,transform.up);
            
            Debug.Log(i);
            Debug.Log("the count of ball" + ballCount);
            BalList.Remove(BalList[i]);
            //BalList.RemoveAt(i);
            await Task.Delay(150);

        }
        //BalList.Clear();
       
    }
    public void StoreBall(Ball ball)
    {
        BalList.Add(ball);
    }
    
}
