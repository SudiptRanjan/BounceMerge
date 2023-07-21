using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public Ball ball;
    public Transform firingPoint;
    public float power;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
        Vector3 mousPosition = Input.mousePosition;
        mousPosition.z = Camera.main.transform.position.z;
       
        Vector3 InputMousePosition = Camera.main.ScreenToWorldPoint( mousPosition);
        //Debug.Log(InputMousePosition);
        Vector3 direction = transform.position - InputMousePosition;

        Debug.Log(direction);

        Quaternion rotation = Quaternion.LookRotation( Vector3.forward,direction);
        //Debug.Log(rotation);
        transform.rotation = rotation;
        


    }

    public void LaunchBalls()
    {
        Ball CreatedCannonball = Instantiate(ball, firingPoint.position, firingPoint.rotation);
        CreatedCannonball.rb.velocity = firingPoint.transform.up * power;
    }
}
