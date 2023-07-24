
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public List<Ball> BalList;
    public Transform firingPoint;
    public static BallLauncher instance;
    //private float power = 20;


    private void Start()
    {
        instance = this;
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

        Vector3 mousPosition = Input.mousePosition;

        mousPosition.z = Camera.main.transform.position.z;
       
        Vector3 InputMousePosition = Camera.main.ScreenToWorldPoint( mousPosition);
        Vector3 direction = transform.position - InputMousePosition;

        //Debug.Log(direction);

        Quaternion rotation = Quaternion.LookRotation( Vector3.forward,direction);
        transform.rotation = rotation;
        
    }

    public async void  LaunchBalls()
    {
        for(int i = 0;i<BalList.Count;i++)
        {
            //BalList[i].transform.position = firingPoint.transform.position;
            //BalList[i].rb.velocity = firingPoint.transform.up * power;
            //BalList[i].transform.position = firingPoint.transform.position;
            //BalList[i].rb.velocity = transform.up * power;
            BalList[i].Shoot(firingPoint,transform.up);
            await Task.Delay(200);
        }

        BalList.Clear();
    }
    public void StoreBall(Ball ball)
    {
        BalList.Add(ball);
    }
}
