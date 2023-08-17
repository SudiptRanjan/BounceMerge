using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : BaseScreen
{
    public Button Startbutton;
    public BallsCollection ballsCollection;
    public BallLauncher ballLauncher;
    // Start is called before the first frame update
    void Start()
    {
        Startbutton.onClick.AddListener(OnClickStart);
    }

    
    public  void OnClickStart()
    {
        GameManager.instance.state = GameState.gamePlay;
        ScreenManager.instance.SwitchScreenBack(ScreenType.Start);
        ballsCollection.InstantiateBalls();
        ballLauncher.EnableTheInput();
        //Debug.Log("start");
    }
}
