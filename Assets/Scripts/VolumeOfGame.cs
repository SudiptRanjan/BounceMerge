using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeOfGame : MonoBehaviour
{
    [SerializeField] private Slider slider;
   

    void Start()
    {

        AudioManager.instance.ChangeVolume(slider.value);
        //ChangeVolume();
        //slider.onValueChanged.AddListener(ChangeVolume());
    }
    public void ChangeVolume()
    {
        AudioManager.instance.ChangeVolume(slider.value);

    }

    public void MuteVolume()
    {
        AudioManager.instance.MuteAudio();
        
    }

}
