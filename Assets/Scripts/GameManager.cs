
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        state = GameState.startScreen;
        Time.timeScale = 1f;
    }

}

public enum GameState
{
    startScreen,
    gamePlay,
    setting,
    fastForward
   
}
