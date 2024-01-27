using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private InputReader reader;

    [SerializeField] private CinemachineVirtualCamera closeCam;
    [SerializeField] private CinemachineVirtualCamera normalCam;

    // Start is called before the first frame update
    void Start()
    {
        reader.OnMenuOpenPerformed += MenuClose;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MenuClose()
    {
        canvas.enabled = false;
        closeCam.enabled = false;
    }
}
