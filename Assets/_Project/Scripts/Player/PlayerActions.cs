using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerActions : MonoBehaviour, IAudioController
{
    public static Action KillPlayer;
    private Animation playeranimation;
    private CapsuleCollider playercollider;
    private Rigidbody playerrigidbody;
    private PlayerMovement playerMovement;

    protected void Awake() {
        playeranimation = GetComponent<Animation>();
        playercollider = GetComponent<CapsuleCollider>();
        playerrigidbody = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
    }

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
        DisablePlayer();
        yield return new WaitForSeconds(2f);
        SceneHandler.ReloadScene?.Invoke();
    }

    void DisablePlayer()
    {
        //TO DO mudar essa função para dentro do player intensity
        PlayerIntensity.TurnOffLight?.Invoke();

        playercollider.enabled = false;
        playerMovement.enabled = false;
        playerrigidbody.isKinematic = true;
        playeranimation.Play("playerDie");
    }
}