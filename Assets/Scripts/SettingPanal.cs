using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingPanal : MonoBehaviour
{
    [SerializeField]private Canvas canvas;
    public Button SettingButton;
    public  BallLauncher ballLauncher;
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale =1;
        SettingButton.onClick.AddListener(OnClickSetting);
    }
    

    private void OnClickSetting()
    {
        canvas.enabled = !canvas.enabled;
        Time.timeScale = 1;
        if (Time.timeScale== 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

}
