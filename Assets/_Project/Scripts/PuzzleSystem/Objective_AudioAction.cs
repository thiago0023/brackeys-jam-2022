using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Objective_AudioAction : PuzzleObjectiveActionBase
{
    [SerializeField] private string OnCompleteObjectiveSound;
    [SerializeField] private string OnUncompleteObjectiveSound;

    protected override void CompleteFeedback()
    {
        if (string.IsNullOrEmpty(OnCompleteObjectiveSound)) return;
        
        AudioHandler.Instance.PlayAudio(enAudioType.SFX, OnCompleteObjectiveSound, false);
        
    }

    protected override void UncompleteFeedback()
    {
        if (string.IsNullOrEmpty(OnUncompleteObjectiveSound)) return;
           
        AudioHandler.Instance.PlayAudio(enAudioType.SFX, OnCompleteObjectiveSound, false);
    }
}
