using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Canvas gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableCamrOver()
    {
        gameOverCanvas.enabled = true;
    }
     
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer ==8)
        {
            AudioManager.instance.PlaySound(AudioManager.SoundName.GameOve);
            EnableCamrOver();
            Debug.Log("Game Over");
            Time.timeScale = 0f;
        }
    }
}
