using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    public static SoundManager inst;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource bg;
    public Sound[] clips;

    public RawImage[] soundBTNS;
    public RawImage[] MusicBTNS;

    public Texture2D SoundON;
    public Texture2D SoundOFF;
    public Texture2D MusicON;
    public Texture2D MusicOFF;


    private bool isBgMuted = false;
    private bool isAudioSourceMuted = false;

    private void Awake()
    {
        inst = this;
    }
    public void PlaySound(SoundName name)
    {
        foreach (var item in clips)
        {
            if (item.name == name)
            {
                audioSource.PlayOneShot(item.clip);
                break;
            }
        }
    }
    public void ToggleMusic()
    {
        bg.mute = isBgMuted = !isBgMuted;

        foreach (RawImage Images in MusicBTNS)
        {
            Images.texture = (isBgMuted) ? MusicOFF : MusicON;
        }

    }

    public void ToggleSound()
    {
        isAudioSourceMuted = !isAudioSourceMuted;
        audioSource.mute = isAudioSourceMuted;

        foreach (RawImage Images in soundBTNS)
        {
            if (isAudioSourceMuted == true)
                Images.texture = SoundOFF;
            else
                Images.texture = SoundON;
        }
    }
}

[System.Serializable]
public class Sound
{
    public SoundName name;
    public AudioClip clip;
}
public enum SoundName
{
    CubeCollision, ButtonClick, GameOver, CubePopup
}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class PopupValue : MonoBehaviour
//{
//    public TextMeshPro ballNoPopUp;
//    private int ballNoInTextPopup;
//    public Color textColor;

//    private void Awake()
//    {
//        ballNoPopUp = GetComponentInChildren<TextMeshPro>();
//    }

//    void Start()
//    {
//        StartCoroutine(PopupCoroutine());
//    }

//    IEnumerator PopupCoroutine()
//    {
//        float moveSpeed = 0.54f;
//        float timerSpeed = 3.5f;

//        while (textColor.a > 0)
//        {
//            transform.position += Vector3.up  moveSpeed Time.deltaTime;

//            textColor.a -= timerSpeed * Time.deltaTime;
//            ballNoPopUp.color = textColor;

//            yield return null;
//        }

//        Destroy(gameObject);
//    }

//    public void SpawnValue(Vector3 popPosition, int ballValue)
//    {
//        GameObject spawnPop = Instantiate(gameObject, popPosition, Quaternion.identity);
//        SetBallNo(ballValue);
//    }

//    public void SetBallNo(int ballNoInText)
//    {
//        ballNoInTextPopup = ballNoInText;
//        ballNoPopUp.SetText(ballNoInTextPopup.ToString());
//        textColor = ballNoPopUp.color;
//    }
//}
