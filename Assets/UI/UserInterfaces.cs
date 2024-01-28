using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterfaces : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TriggerAudioCollection.Instance.PlayNarratorSound(EAudioType.Narration_Opening);
        TriggerAudioCollection.Instance.PlayBGSound(EAudioType.BG_IntroMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
}
