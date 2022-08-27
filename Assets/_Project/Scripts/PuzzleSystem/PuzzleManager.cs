using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private PuzzleObjective[] _puzzleObjectives;
    [SerializeField] private PuzzleCompleteBase[] _puzzleCompleteActions;
    public event EventHandler OnPuzzleStart;
    public static event EventHandler<PuzzleManager> OnPuzzleSolved;

    [SerializeField] private bool autoStart = true;

    private void Awake() {
        _puzzleObjectives = GetComponentsInChildren<PuzzleObjective>();
        _puzzleCompleteActions = GetComponentsInChildren<PuzzleCompleteBase>();
        
        foreach (var objective in _puzzleObjectives) {
            objective.AssignPuzzleManager(this);
        }

        foreach (var completeAction in _puzzleCompleteActions) {
            completeAction.AssignPuzzleManager(this);
        }
    }

    private void OnEnable() {
        PuzzleObjective.OnObjectiveStatusChange += PuzzleObjective_OnObjectiveStatusChange;
    }

    private void OnDisable() {
        PuzzleObjective.OnObjectiveStatusChange -= PuzzleObjective_OnObjectiveStatusChange;
    }

    private void Start() {
        if (autoStart) {
            OnPuzzleStart?.Invoke(this, EventArgs.Empty);
        }
    }

    public void PuzzleObjective_OnObjectiveStatusChange(object sender, OnObjectStatusChangeArgs e) {
        if (e.puzzleManager != this) return;

        if (e.status) CheckPuzzleSolved();
    }

    private void CheckPuzzleSolved() {
        foreach (PuzzleObjective objective in _puzzleObjectives) {
            if (!objective.IsObjectiveCompleted()) {
                return;
            }
        }
        OnPuzzleSolved?.Invoke(this, this);
    }

}
