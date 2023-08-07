using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public BaseScreen [] screens;
    public BaseScreen currentScreen;
    public static ScreenManager instance;
    private void Awake()
    {
        instance = this;
        currentScreen.canvas.enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchScreen(ScreenType screenType)
    {
        currentScreen.canvas.enabled = false;
        foreach (BaseScreen baseScreen in screens)
        {
            if (baseScreen.screenType == screenType)
            {
                baseScreen.canvas.enabled = true;
                currentScreen = baseScreen;
                Debug.Log("loop failed");
                break;
            }
        }
    }

    public void SwitchScreenBack(ScreenType screenType)
    {
        //currentScreen.canvas.enabled = false;
        foreach (BaseScreen baseScreen in screens)
        {
            //if (baseScreen.screenType == screenType)
            {
                baseScreen.canvas.enabled = false;
                //currentScreen = baseScreen;
                //Debug.Log("loop failed");
                //break;
            }
        }
    }

}
