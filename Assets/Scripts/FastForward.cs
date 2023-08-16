using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForward : MonoBehaviour
{
    public Button fastForwardButton;

    // Start is called before the first frame update
    void Start()
    {
        fastForwardButton.onClick.AddListener(OnClickFastForward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickFastForward()
    {
        Time.timeScale = 10f;
    }

}
