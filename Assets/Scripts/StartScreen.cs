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
    public BlockSpawner blockSpawner;
    // Start is called before the first frame update
    void Start()
    {
        Startbutton.onClick.AddListener(OnClickStart);
    }

    
    public  void OnClickStart()
    {
        ScreenManager.instance.SwitchScreenBack(ScreenType.Start);
        ballsCollection.InstantiateBalls();
        ballLauncher.EnableTheInput();
        ballLauncher.clickedOn = true;
        blockSpawner.SpawnBlocks();
        //Debug.Log("start");
    }
}
