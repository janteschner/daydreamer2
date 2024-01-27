using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TriggerAudioCollection : MonoBehaviour
{
    [SerializeField] public List<AudioClip> AudioClipList;
    AudioSource Source;

    private void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    public void PlayAudioSource(EAudioType audioSource, float volume)
    {
        Source.clip = AudioClipList[(int)audioSource];
        Source.volume = volume;
        Source.Play();
    }
}
