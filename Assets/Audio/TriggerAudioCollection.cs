using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TriggerAudioCollection : MonoBehaviour
{
    
    public static TriggerAudioCollection Instance { get; private set; }
    private AudioSource _source;

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

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlaySound(EAudioType audioSource)
    {
        if (PlayAudio)
        {
            // _source.clip = AudioClipList[(int)audioSource];
            _source.PlayOneShot(AudioClipList[(int)audioSource], 1f);
            // AudioSource.PlayClipAtPoint(AudioClipList[(int)audioSource], position, 10);
        }
    }
}
