using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PuzzleObjective))]
public class Interaction_WispStand : InteractionWithKey
{
    public event EventHandler OnWispStandActivated;
    public event EventHandler OnWispStandDeactivated;
    private bool hasWisp = false;
    private PuzzleObjective _puzzleObjective;
    private WispStand_Feedback _feedback;

    private void Awake() {
        _puzzleObjective = GetComponent<PuzzleObjective>();
        _feedback = GetComponentInChildren<WispStand_Feedback>();
    }

    private void Start() {
        OnWispStandActivated += Self_OnWispStandActivated;
        OnWispStandDeactivated += Self_OnWispStandDeactivated;
    }
    public override void Interact()
    {
        if (!_puzzleObjective.IsActive()) return;

        if (hasWisp) {
            OnWispStandDeactivated?.Invoke(this, EventArgs.Empty);
        }
        else {
            OnWispStandActivated?.Invoke(this, EventArgs.Empty);
        }    
    }

    private void Self_OnWispStandActivated(object sender, EventArgs e)
    {
        if(!PlayerStorage.CanPlayerGiveWisps.Invoke()) return;

        PlayerStorage.DecreaseLight?.Invoke(1);
        hasWisp = true;
        _feedback.PlaceWisp(hasWisp);
        _puzzleObjective.ChangeObjectiveStatus(hasWisp);
    }

    private void Self_OnWispStandDeactivated(object sender, EventArgs e)
    {
        PlayerStorage.IncreaseLight?.Invoke(1);
        hasWisp = false;
        _feedback.PlaceWisp(hasWisp);
        _puzzleObjective.ChangeObjectiveStatus(hasWisp);
    }

}
