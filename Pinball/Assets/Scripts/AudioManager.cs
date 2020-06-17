using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
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
            s.audioSource.name = s.name;
            s.audioSource.volume = s.volume;
            s.audioSource.loop = s.loop;
            s.audioSource.pitch = s.pitch;
        }
    }

    // Update is called once per frame
    public void StartPlaying(string name)
    {

    } 
    public void StopPlaying(string name)
    {

    }
    public void RestartPlaying(string name)
    {

    }
}
