using UnityEngine.Audio;
using UnityEngine;
using System;

[Serializable]
public class Sound
{
    public AudioClip audioClip;
    public string name;
    [Range(0f,1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    public Boolean loop;
    public AudioSource audioSource;

}
