using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource audioSource;
    
    public Sound[] clips;

    //public Sound[] sounds;
    private void Awake()
    {
        //if (inst == null)
        {

            instance = this;
        }
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        //foreach (Sound s in sounds)
        //{
        //    s.source = gameObject.AddComponent<AudioSource>();
        //    s.source.clip = s.clip;
        //    s.source.volume = s.volume;
        //    s.source.pitch = s.pitch;
        //    s.source.loop = s.loop;
        //}
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
//private void Start()
//{
//    Play("Music");
////}
//    public void Play(string name)
//    {
//        Sound s = Array.Find(sounds, sound => sound.name == name);
//        s.source.Play();

//    }
    [System.Serializable]
    public class Sound
    {
        public SoundName name;
        public AudioClip clip;
    }

    public enum SoundName
    {
        BounceBall, GameOve
    }

}



