using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PuzzleObjective))]
public class WispStand_Timer : WispStand
{
    [SerializeField] private float timeToDeactivate = 5f; 
    private float resetTimerValue;

    protected override void Awake() {
        base.Awake();
        resetTimerValue = timeToDeactivate;
    }

    private void ResetTimer() {
        timeToDeactivate = resetTimerValue;
    }

    private void Update() {
        var isAbleToDeactivate = hasWisp && _puzzleObjective.IsActive();
       
        if (!isAbleToDeactivate) return;

        timeToDeactivate -= Time.deltaTime;
        if (timeToDeactivate <= 0) {
            SetStandActivation(false);
        }
    }

    protected override void SetStandActivation(bool status) {
        base.SetStandActivation(status);
        ResetTimer();
    }


}