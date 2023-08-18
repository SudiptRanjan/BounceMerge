using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingPanal : MonoBehaviour
{
    //[SerializeField] private Canvas canvas;
    public GameObject settingPanal;
    public bool gameIsPaused = false;
    void Start()
    {
        //Time.timeScale =1;
        //SettingButton.onClick.AddListener(OnClickSetting);
    }


  

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            if (gameIsPaused)
            {
                Resumed();
            }
            else
            {
                Paused();
            }
        }

       

    }
    public void Paused()
    {
        settingPanal.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Debug.Log("paused");

    }

    public void Resumed()
    {
        settingPanal.SetActive(false);
        Time.timeScale = 0.7f;
        gameIsPaused = false;
    }
}
