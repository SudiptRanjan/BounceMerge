using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class PopupValue : MonoBehaviour
{
    public TextMeshPro ballNoPopUp;
    private int ballNoInTextPopup;
    public float timer;
    public Color textColor;
    //private TextMesh textMesh;
    //public GameObject popUprefab;
    private void Awake()
    {
        ballNoPopUp = GetComponentInChildren<TextMeshPro>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     void Update()
    {

        float moveSpeed = 0.1f;
        //await Task.Delay(200);
        transform.position += Vector3.up * moveSpeed;
        //await Task.Delay(1000);
        //Destroy(gameObject);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            float timerSpeed = 0.5f;
            textColor.a -= timerSpeed * Time.deltaTime;
            ballNoPopUp.color = textColor;
            if (textColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SpawnValue(Vector3 popPosition,int ballValue)
    {
        GameObject spawnPop = Instantiate(gameObject, popPosition, Quaternion.identity);
        //Debug.Log(spawnPop);
        SetBallNo(ballValue);
    }
    public void SetBallNo(int ballNoInText)
    {
        ballNoInTextPopup = ballNoInText;
        ballNoPopUp.SetText(ballNoInTextPopup.ToString());
        textColor = ballNoPopUp.color;
    }
   

}