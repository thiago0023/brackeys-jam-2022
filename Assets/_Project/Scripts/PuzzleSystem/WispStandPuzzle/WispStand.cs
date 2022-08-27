using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PuzzleObjective))]
public class WispStand : InteractionWithKey
{
    public static event EventHandler OnWispStandActivated;
    public  static event EventHandler OnWispStandDeactivated;
    public static event EventHandler<OnAnyWispStandArgs> OnAnyWispInteracted;

    protected bool hasWisp = false;
    protected PuzzleObjective _puzzleObjective;
    protected WispStand_Feedback _feedback;

    protected virtual void Awake() {
        _puzzleObjective = GetComponent<PuzzleObjective>();
        _feedback = GetComponentInChildren<WispStand_Feedback>();
    }

    private void OnEnable() {
        PlayerStorage.WispStand_OnIncreaseWispAmount += PlayerStorage_OnIncreaseWisp;
        PlayerStorage.WispStand_OnDecreaseWispAmount += PlayerStorage_OnDecreaseWisp;
    }

    private void OnDisable() {
        PlayerStorage.WispStand_OnIncreaseWispAmount -= PlayerStorage_OnIncreaseWisp;
        PlayerStorage.WispStand_OnDecreaseWispAmount -= PlayerStorage_OnDecreaseWisp;
    }

    public override void Interact()
    {
        if (!_puzzleObjective.IsActive()) return;

        OnAnyWispInteracted?.Invoke(this, new OnAnyWispStandArgs { wispStand = this, hasWisp = hasWisp });
    }

    protected virtual void SetStandActivation(bool status) {
        hasWisp = status;
        if (status) {
            OnWispStandActivated?.Invoke(this, EventArgs.Empty);
        } else {
            OnWispStandDeactivated?.Invoke(this, EventArgs.Empty);
        }
        _feedback.PlaceWisp(status);
        _puzzleObjective.ChangeObjectiveStatus(status);
    }

    public bool GetState() => hasWisp;

    private void PlayerStorage_OnIncreaseWisp (object sender, OnAnyWispStandArgs e) {
        if(e.wispStand != this) return;

        SetStandActivation(e.hasWisp);
    }

    private void PlayerStorage_OnDecreaseWisp (object sender, OnAnyWispStandArgs e) {
        if(e.wispStand != this) return;

        SetStandActivation(e.hasWisp);
    }

    public override void BeginInteraction()
    {
        throw new NotImplementedException();
    }

    public override void EndInteraction()
    {
        throw new NotImplementedException();
    }
}

public class OnAnyWispStandArgs : EventArgs
{
    public WispStand wispStand;
    public bool hasWisp;

}