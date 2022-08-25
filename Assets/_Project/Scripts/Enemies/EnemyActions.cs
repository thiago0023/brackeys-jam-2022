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
            AudioHandler.Instance.PlayBGS("Player De", audioSource);
        }
    }
}