using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : BaseScreen
{
    public Button gameOverButton;
    // Start is called before the first frame update
    void Start()
    {
        gameOverButton.onClick.AddListener(OnclicGameOver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnclicGameOver()
    {
        ScreenManager.instance.SwitchScreen(ScreenType.Start);
    }
   
}
