using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuckThisShitWhyCantIJustAnimateItSimply : MonoBehaviour
{
    [SerializeField]
    public float T_in = 0.0f;
    public Material mat_in;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        T_in = Mathf.Clamp(T_in, 0.0f, 0.999f);
        mat_in.SetFloat("_T", T_in);
    }
}
