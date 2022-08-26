using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyActions : CharacterSettings
{
    protected override void Start()
    {
        base.Start();
        if(audioSourceFound)
        {
            AudioHandler.Instance.PlayAudio(audioList[0].audioType, audioList[0].audioName, true, audioSource);
        }
    }
}