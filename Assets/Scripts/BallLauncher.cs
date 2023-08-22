using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallLauncher : MonoBehaviour
{
    public List<Ball> BalList;
    public Transform firingPoint;
    public Transform endLine;
    public int ballCount;
    public BallsCollection ballsCollection;
    public LineRenderer lineRenderer;
    public bool clicked;
    public bool clickedOn= true;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        DisableTheInput();
    }
    private void OnEnable()
    {
        PlayerInput.OnClick += CreateLineRenderer;
        PlayerInput.OnClick += RotateTheBallLauncher;
        PlayerInput.OnClickUp += LaunchBalls;
        Block.AddNewBallsToList += IncreaseBallCount;
        BallsCollection.MergingOfBall += MergeBalls;
        GameOver.OnGameOverClearList += ClearBallList;

    }

    private void OnDisable()
    {
        PlayerInput.OnClick -= CreateLineRenderer;
        PlayerInput.OnClick -= RotateTheBallLauncher;
        PlayerInput.OnClickUp -= LaunchBalls;
        Block.AddNewBallsToList -= IncreaseBallCount;
        BallsCollection.MergingOfBall -= MergeBalls;
        GameOver.OnGameOverClearList -= ClearBallList;
    }
    private void Update()
    {
        if(clickedOn)
        {
            IsMousePointerOnUI();

        }
      
    }

    public void StoreBall(Ball ball)
    {
        BalList.Add(ball);

    }

    public void EnableTheInput()
    {
        gameObject.GetComponent<PlayerInput>().enabled = true;
    }

    public void DisableTheInput()
    {
        gameObject.GetComponent<PlayerInput>().enabled = false;
    }
    public void ClearBallList()
    {
        for (int i = ballCount - 1; i >= 0; i--)
        {
            Ball ball = BalList[i];
            Destroy(ball.gameObject);
            BalList.RemoveAt(i);
            ballCount--;
        }

    }
    private void CreateLineRenderer()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firingPoint.position);
        lineRenderer.SetPosition(1, endLine.position);
    }


    private void RotateTheBallLauncher()
    {
        Vector3 mousPosition = Input.mousePosition;
        mousPosition.z = Camera.main.transform.position.z;
        Vector3 InputMousePosition = Camera.main.ScreenToWorldPoint(mousPosition);
        Vector3 direction = transform.position - InputMousePosition;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = rotation;
    }

    private async void LaunchBalls()
    {
        Time.timeScale = 0.5f;
        lineRenderer.enabled = false;
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
        clickedOn = false;
    }

    private void IncreaseBallCount()
    {
        ballCount++;
    }
   

    private async void MergeBalls()
    {
        //int pointlistCount = ballsCollection.pointList.Count - 1;
        bool merged = true;
        while (merged)
        {
            merged = false;
            for (int i = ballCount - 1; i > 0; i--)
            {

                if (BalList[i - 1].ballNo == BalList[i].ballNo)
                {
                    BalList[i].ballNo *= 2;
                    //int max= Mathf.Max(BalList[i].ballNo);
                    BalList[i].UpdateText();
                    Ball ball = BalList[i - 1];
                    //Debug.Log("Did not merge");

                    BalList.Remove(ball);
                    Destroy(ball.gameObject);
                    ballCount--;
                    //Debug.Log("Max value in the list ==="+Mathf.Max(BalList[i].ballNo));
                    merged = true;
                    List<Ball> MergedBallsList = new List<Ball>();
                    MergedBallsList.AddRange(BalList);
                    for (int j = 0; j < MergedBallsList.Count; j++)
                    {
                        if (j <= ballsCollection.pointList.Count - 1)
                        {
                            MergedBallsList[j].transform.position = ballsCollection.pointList[j].transform.position;
                            //Debug.Log(" Merged And move forward");
                        }
                        else
                        {
                            Debug.Log("Can't be Merged And move forward");
                        }
                        //MergedBallsList[j].transform.position = ballsCollection.pointList[j].transform.position;
                    }

                    await Task.Delay(500);

                    break;
                }
            }
        }
        gameObject.GetComponent<PlayerInput>().enabled = true;
        clickedOn = true;
    }

    private void IsMousePointerOnUI()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject() || EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                clicked = true;
                if (clicked == true)
                {
                    DisableTheInput();
                }


            }
            else
            {
                clicked = false;
                if (clicked == false)
                {
                    EnableTheInput();
                }


            }
        }
        
    }
}
//for (int j = 0; j < MergedBallsList.Count; j++)