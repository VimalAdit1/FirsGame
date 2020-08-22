using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Use the name provided under Name in inspector not the fileName
    // Start is called before the first frame update
    public Sound[] sounds;
    public static AudioManager instance;
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();

            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.loop = s.loop;
            s.audioSource.pitch = s.pitch;
        }
    }

    // Update is called once per frame
    public void StartPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound=>sound.name == name);
        if (s != null)
        {
            s.audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Sound file " + name + " not found");
        }
    } 
    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.audioSource.Stop();
        }
        else
        {
            Debug.LogWarning("Sound file " + name + " not found");
        }
    }
   
}
