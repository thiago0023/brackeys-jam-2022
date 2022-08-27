using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObjective : MonoBehaviour
{

    protected PuzzleManager _puzzleManager;
    protected bool isActive;
    protected bool isCompleted;

    public static event EventHandler<OnObjectStatusChangeArgs> OnObjectiveStatusChange;
    
    private void OnEnable() {
        PuzzleManager.OnPuzzleSolved += PuzzleManager_OnPuzzleSolved;
    }

    private void OnDisable() {
        PuzzleManager.OnPuzzleSolved -= PuzzleManager_OnPuzzleSolved;
    }

    public void AssignPuzzleManager(PuzzleManager puzzleManager)
    {
        _puzzleManager = puzzleManager;
        _puzzleManager.OnPuzzleStart += PuzzleManager_OnPuzzleStart;
    }

    public bool SetObjectiveActivation(bool active) => isActive = active;
    public void ChangeObjectiveStatus(bool status) {
        isCompleted = status;
        OnObjectiveStatusChange?.Invoke(this, new OnObjectStatusChangeArgs{
            status = status,
            puzzleManager = _puzzleManager
        });
    }
    
    public bool IsObjectiveCompleted() => isCompleted;
    public bool IsActive() => isActive;

    private void PuzzleManager_OnPuzzleSolved(object sender, PuzzleManager puzzleManager)
    {
        if (puzzleManager == _puzzleManager) {
            SetObjectiveActivation(false);
        }
    }

    private void PuzzleManager_OnPuzzleStart(object sender, EventArgs e)
    {
        SetObjectiveActivation(true);
    }    
    
}

public class OnObjectStatusChangeArgs: EventArgs
{
    public bool status;
    public PuzzleManager puzzleManager;
}