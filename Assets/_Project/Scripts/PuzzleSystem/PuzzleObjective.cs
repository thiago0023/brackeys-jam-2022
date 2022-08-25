using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObjective : MonoBehaviour
{

    protected PuzzleManager _puzzleManager;
    protected bool isActive;
    protected bool isCompleted;

    public event EventHandler<bool> OnObjectiveStatusChange;
    
    public void AssignPuzzleManager(PuzzleManager puzzleManager)
    {
        _puzzleManager = puzzleManager;
        _puzzleManager.OnPuzzleStart += PuzzleManager_OnPuzzleStart;
        _puzzleManager.OnPuzzleSolved += PuzzleManager_OnPuzzleSolved;
    }

    public bool SetObjectiveActivation(bool active) => isActive = active;
    public void ChangeObjectiveStatus(bool status) {
        isCompleted = status;
        OnObjectiveStatusChange?.Invoke(this, status);
    }
    
    public bool IsObjectiveCompleted() => isCompleted;
    public bool IsActive() => isActive;

    private void PuzzleManager_OnPuzzleSolved(object sender, EventArgs e)
    {
        SetObjectiveActivation(false);
    }

    private void PuzzleManager_OnPuzzleStart(object sender, EventArgs e)
    {
        SetObjectiveActivation(true);
    }    
    
}
