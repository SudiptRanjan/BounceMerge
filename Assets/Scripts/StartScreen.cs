using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : BaseScreen
{
    public Button Startbutton;
    // Start is called before the first frame update
    void Start()
    {
        Startbutton.onClick.AddListener(OnClickStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStart()
    {
        ScreenManager.instance.SwitchScreenBack(ScreenType.Start);
    }
}
