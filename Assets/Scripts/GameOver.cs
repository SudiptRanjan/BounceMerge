using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Canvas gameOverCanvas;
    public delegate void ClearAll();
    public static event ClearAll OnGameOverClearList;
    public BallLauncher ballLauncher;
    public void EnableCamrOver()
    {
        //gameOverCanvas.enabled = true;
        ScreenManager.instance.SwitchScreen(ScreenType.GameOver);
    }
     
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer ==8)
        {
            AudioManager.instance.PlaySound(AudioManager.SoundName.GameOve);
            OnGameOverClearList();
            EnableCamrOver();
            //SpawnBlocks()
            ScoreUpdate.instance.ScoreWhenGameOver();
            ballLauncher.DisableTheInput();
           
        }
    }
}
