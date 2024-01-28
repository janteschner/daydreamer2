using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundTrainScript : MonoBehaviour
{

    private String StartTrain = "StartTrain";

    private Animator _animator;

    private Vector3 normalSize;
    
    public static BackgroundTrainScript Instance { get; private set; }

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
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        Debug.Log(transform.localScale);
        normalSize = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    public void PlayTrainAnimation()
    {
        transform.localScale = normalSize;
        _animator.SetTrigger(StartTrain);
        
    }

    public void OnAnimationFinish()
    {
        transform.localScale = Vector3.zero;
        Debug.Log("EBENDE!");
    }
}
