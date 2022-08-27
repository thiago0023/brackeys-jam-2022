using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PuzzleCompleteAction_PlayAudio : PuzzleCompleteBase
{
    [SerializeField] private string OnCompleteObjectiveSound;

    protected override void CompletePuzzle()
    {
        if (string.IsNullOrEmpty(OnCompleteObjectiveSound)) return;
        
        AudioHandler.Instance.PlayAudio(enAudioType.SFX, OnCompleteObjectiveSound, false);
    }

}
