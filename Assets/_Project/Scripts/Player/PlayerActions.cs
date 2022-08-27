using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerActions : CharacterSettings
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
        PlayerStorage.PlayerAction_OnKillPlayer += PlayerStorage_OnKillPlayer;
        PlayerIntensity.OnLightOff += PlayerIntensity_OnLightOff;
    }

    void OnDisable()
    {
        KillPlayer -= OnKillPlayer;
        PlayerStorage.PlayerAction_OnKillPlayer -= PlayerStorage_OnKillPlayer;
        PlayerIntensity.OnLightOff -= PlayerIntensity_OnLightOff;
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

    private void PlayerStorage_OnKillPlayer(object sender, System.EventArgs e)
    {
        OnKillPlayer();
    }

    private void PlayerIntensity_OnLightOff()
    {
        OnKillPlayer();
    }
}