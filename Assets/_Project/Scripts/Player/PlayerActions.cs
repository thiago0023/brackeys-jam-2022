using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerActions : MonoBehaviour
{
    public static Action KillPlayer;

    void OnEnable()
    {
        KillPlayer += OnKillPlayer;
    }

    void OnDisable()
    {
        KillPlayer -= OnKillPlayer;
    }

    void OnKillPlayer()
    {
        StartCoroutine("ReloadDelay");
    }

    IEnumerator ReloadDelay()
    {
        PlayerIntensity.TurnOffLight?.Invoke();
        var animation = GetComponent<Animation>();
        var collider = GetComponent<CapsuleCollider>();
        var rigidbody = GetComponent<Rigidbody>();
        collider.enabled = false;
        rigidbody.isKinematic = true;
        print(animation);
        animation.Play("playerDie");
        yield return new WaitForSeconds(2f);
        SceneHandler.ReloadScene?.Invoke();
    }
}
