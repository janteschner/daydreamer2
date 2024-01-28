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
    public AudioSource narrSource;

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
            DontDestroyOnLoad(transform.root);
        }
    }
    

    public void PlaySound(EAudioType audioSource, float volume = 1f)
    {
        sfxSource.PlayOneShot(AudioClipList[(int)audioSource], volume);
    }    
    
    public void PlayBGSound(EAudioType audioSource, float volume = 1f)
    {
        bgmSource.PlayOneShot(AudioClipList[(int)audioSource], volume);
    }    
    
    public void PlayNarratorSound(EAudioType audioSource, float volume = 1f)
    {
        narrSource.PlayOneShot(AudioClipList[(int)audioSource], volume);
    }
}
