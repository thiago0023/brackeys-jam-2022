using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleObjective : MonoBehaviour
{

    protected PuzzleManager _puzzleManager;
    protected bool isActive;
    protected bool isCompleted;

    public event EventHandler<bool> OnObjectiveStatusChange;
    
    protected void AssignPuzzleManager(PuzzleManager puzzleManager)
    {
        _puzzleManager = puzzleManager;
    }

    protected bool SetObjectiveActivation(bool active) => isActive = active;
    protected bool ChangeObjectiveStatus(bool status) => isActive = status;

    private void PuzzleManager_OnPuzzleSolved(object sender, EventArgs e)
    {
        SetObjectiveActivation(false);
    }

    private void PuzzleManager_OnPuzzleStart(object sender, EventArgs e)
    {
        SetObjectiveActivation(true);
    }

    
    
}
