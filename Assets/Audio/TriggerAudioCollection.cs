using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TriggerAudioCollection : MonoBehaviour
{
    
    public static TriggerAudioCollection Instance { get; private set; }
    public AudioSource sfxSource;
    public AudioSource bgmSource;

    [SerializeField] public List<AudioClip> AudioClipList;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }
    

    public void PlaySound(EAudioType audioSource, float volume = 1f)
    {
        sfxSource.PlayOneShot(AudioClipList[(int)audioSource], volume);
    }
}
