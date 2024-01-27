using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TriggerAudioCollection : MonoBehaviour
{
    
    public static TriggerAudioCollection Instance { get; private set; }

    [SerializeField] public List<AudioClip> AudioClipList;
    [SerializeField] AudioSource StorytellingSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] bool PlayAudio;

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

    public void PlayAudioSource(EAudioType audioSource, float volume, bool isSFX)
    {
        if (PlayAudio)
        {
            var source = isSFX ? SFXSource : StorytellingSource;
            source.clip = AudioClipList[(int)audioSource];
            source.volume = volume;
            source.Play();
        }
    }
}
