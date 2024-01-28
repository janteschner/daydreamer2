using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TriggerAudioCollection : MonoBehaviour
{
    
    public static TriggerAudioCollection Instance { get; private set; }

    [SerializeField] public List<AudioClip> AudioClipList;
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
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = AudioClipList[(int)audioSource];
            source.volume = volume;
            source.Play();
        }
    }

    public void PlayAudioSource(EAudioType audioSource, Vector3 position)
    {
        if (PlayAudio)
        {
            AudioSource.PlayClipAtPoint(AudioClipList[(int)audioSource], position);
        }
    }
}
