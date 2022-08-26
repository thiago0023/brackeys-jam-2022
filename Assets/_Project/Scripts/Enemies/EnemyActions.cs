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
            print(audioList[0].audioName);
            AudioHandler.Instance.PlayAudio(audioList[0].audioType, audioList[0].audioName, true, audioSource);
        }
    }
}