using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    private TextMeshPro numberText;
    public int hitNumber =7;
    public Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {
        numberText = GetComponentInChildren<TextMeshPro>();
        //UpdateTheText();
        //numberText.SetText(hitNumber.ToString());
    }
   
    // Update is called once per frame
    public void SetBlockNo(int hits)
    {
        hits = hitNumber;
        UpdateTheText();
    }
    void UpdateTheText()

    {
        numberText.SetText(hitNumber.ToString());

    }
    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if(ball!= null)
        {
            hitNumber -= ball.ballNo;
            Debug.Log("ball value===" + ball.ballNo);
            //hitNumber--;
            if (hitNumber > 0)
            {
                UpdateTheText();
            }
            else
            {
                Destroy(gameObject);
            }
        }
       
    }
}
