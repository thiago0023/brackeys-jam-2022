using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerActions : CharacterSettings
{
    public static Action KillPlayer;
    private Animation playeranimation;
    private CharacterController characterController;
    private PlayerMovement playerMovement;

    protected void Awake() {
        playeranimation = GetComponent<Animation>();
        characterController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    protected override void Start()
    {
        base.Start();
        if(audioSourceFound)
        {
            AudioHandler.Instance.PlayAudio(audioList[0].audioType, audioList[0].audioName, true, audioSource);
        }
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
        PlayerDead();
        yield return new WaitForSeconds(2f);
        SceneHandler.ReloadScene?.Invoke();
    }

    void DisablePlayer()
    {
        playerMovement.enabled = false;
    }
    void EnablePlayer()
    {
        playerMovement.enabled = true;
    }

    void PlayerDead()
    {
        PlayerIntensity.TurnOffLight?.Invoke();
        playeranimation.Play("player_die");
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