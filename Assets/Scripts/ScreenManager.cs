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
    }

    void Start()
    {
        currentScreen.canvas.enabled = true;

    }

    public void SwitchScreen(ScreenType screenType)
    {
        //currentScreen.canvas.enabled = false;
        ToDisableCurrentScreen();
        foreach (BaseScreen baseScreen in screens)
        {
            if (baseScreen.screenType == screenType)
            {
                baseScreen.canvas.enabled = true;
                currentScreen = baseScreen;
                //Debug.Log("loop failed");
                break;
            }
        }
    }

    public void SwitchScreenBack(ScreenType screenType)
    {
        ToEnableCurrentScreen();
       // currentScreen.canvas.enabled = true;
        foreach (BaseScreen baseScreen in screens)
        {
            if (baseScreen.screenType == screenType)
            {
                baseScreen.canvas.enabled = false;
                currentScreen = baseScreen;
                //Debug.Log("loop failed");
                break;
            }
        }
    }

    public void ToEnableCurrentScreen()
    {
        currentScreen.canvas.enabled = true;
    }
    public void ToDisableCurrentScreen()
    {
        currentScreen.canvas.enabled = false;
    }
}
