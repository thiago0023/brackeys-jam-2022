using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyActions : CharacterSettings
{
    private EnemyMovement enemyMovement;
    private Animation enemyAnimation;
    private void OnEnable() {
        PlayerStorage.EnemyActions_OnKillEnemy += PlayerStorage_OnEnemyKill;
    }

    private void OnDisable() {
        PlayerStorage.EnemyActions_OnKillEnemy -= PlayerStorage_OnEnemyKill;
    }

    protected override void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAnimation = GetComponent<Animation>();
        base.Start();
        if(audioSourceFound)
        {
            AudioHandler.Instance.PlayAudio(audioList[0].audioType, audioList[0].audioName, true, audioSource);
        }
    }

    public void KillEnemy()
    {
        Destroy(gameObject);
    }

    private void PlayerStorage_OnEnemyKill(object sender, OnEnemyInteractArgs e)
    {
        if(e.enemy != this) return;

        StartCoroutine("ReloadDelay");
    }

    IEnumerator ReloadDelay()
    {
        print(audioSourceFound);
        if(audioSourceFound)
        {
            AudioHandler.Instance.PlayAudio(audioList[1].audioType, audioList[1].audioName, false);
        }
        print(audioList[1].audioName);
        enemyAnimation.Play("enemy_1_die");
        DisableEnemy();
        yield return new WaitForSeconds(1.2f);
        KillEnemy();
    }

    void DisableEnemy()
    {
        enemyMovement.enabled = false;
    }
}