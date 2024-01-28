using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGunScript : MonoBehaviour
{
    private Animation _animation;
    // Start is called before the first frame update
    void Start()
    {
        _animation = GetComponentInChildren<Animation>();
        TriggerAudioCollection.Instance.PlaySound(EAudioType.SFX_Fake_Gun);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_animation.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
