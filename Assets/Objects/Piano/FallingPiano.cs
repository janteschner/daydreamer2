using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPiano : MonoBehaviour
{
    public float despawnSpeed;
    private Rigidbody _rigidbody;

    private bool alreadyHit = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(Vector3.down * 20f, ForceMode.Impulse);

    }

    private void Update()
    {
        if (alreadyHit) return;
        _rigidbody.AddForce(Vector3.down * 1f, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (alreadyHit) return;
        alreadyHit = true;
        TriggerAudioCollection.Instance.PlaySound(EAudioType.SFX_Piano_Crash);
        GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 100);
        var hitboxComponent = GetComponentInChildren<HitboxScript>();
        Destroy(hitboxComponent);
        StartCoroutine(Despawn());
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(0.5f);
        while (transform.localScale.x > 0)
        {
            var newScale = transform.localScale.x - despawnSpeed * Time.deltaTime;
            transform.localScale = new Vector3(newScale, newScale, newScale);
            yield return null;
        }
        Destroy(gameObject);
    }
}
