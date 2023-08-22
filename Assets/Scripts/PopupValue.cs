using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class PopupValue : MonoBehaviour
{
    public TextMeshPro ballNoPopUp;
    private int ballNoInTextPopup;
    //public float timer;
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
        //StartCoroutine(HitPopUp());
    }

    // Update is called once per frame
    void Update()
    {

        float moveSpeed = 0.54f;
        transform.position += Vector3.up * moveSpeed;

        {
            float timerSpeed = 3.5f;
            textColor.a -= timerSpeed * Time.deltaTime;
            ballNoPopUp.color = textColor;
            if (textColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SpawnValue(Vector3 popPosition, int ballValue)
    {
        GameObject spawnPop = Instantiate(gameObject, popPosition, Quaternion.identity);
        SetBallNo(ballValue);
    }
    public void SetBallNo(int ballNoInText)
    {
        ballNoInTextPopup = ballNoInText;
        ballNoPopUp.SetText(ballNoInTextPopup.ToString());
        textColor = ballNoPopUp.color;
    }

    //IEnumerator HitPopUp()
    //{
    //    float timerSpeed = 3.5f;

    //    ballNoPopUp.color = textColor;
    //    textColor.a -= timerSpeed * Time.deltaTime;

    //    Debug.Log(textColor.a);


    //    //while (textColor.a <= 0)
    //    //{
    //    Debug.Log("Pop up");
    //    float moveSpeed = 0.54f;
    //    transform.position += Vector3.up * moveSpeed;
    //    ballNoPopUp.color = textColor;

    //    //}
    //    Destroy(gameObject);
    //    yield return null;
        
    //}

}