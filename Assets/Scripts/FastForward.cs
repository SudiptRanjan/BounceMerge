using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForward : MonoBehaviour
{
    public Button fastForwardButton;
    public BallLauncher ballLauncher;

    // Start is called before the first frame update
    void Start()
    {

        //fastForwardButton.onClick.AddListener(OnClickFastForward);
        fastForwardButton.onClick.AddListener(OnClickFastForward);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickFastForward()
    {
        
        Time.timeScale = 3f;
        Debug.Log("fast forwarded");
    }

}
