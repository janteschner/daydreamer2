using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TriggerAudioCollection : MonoBehaviour
{
    [SerializeField] public List<AudioClip> AudioClipList;
    [SerializeField] AudioSource Source;
    [SerializeField] bool PlayAudio;

    private void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    public void PlayAudioSource(EAudioType audioSource, float volume, bool isSFX)
    {
        if (PlayAudio)
        {
            Source.clip = AudioClipList[(int)audioSource];
            Source.volume = volume;
            Source.Play();
        }
    }
}
