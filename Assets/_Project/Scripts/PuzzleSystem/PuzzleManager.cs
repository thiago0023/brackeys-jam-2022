using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private PuzzleObjective[] _puzzleObjectives;
    public event EventHandler OnPuzzleStart;
    public event EventHandler OnPuzzleSolved;

    [SerializeField] private bool autoStart = true;

    private void Awake() {
        foreach (PuzzleObjective objective in _puzzleObjectives) {
            objective.AssignPuzzleManager(this);
            objective.OnObjectiveStatusChange += PuzzleObjective_OnObjectiveStatusChange;
        }
        OnPuzzleStart += Self_PuzzleStarted;
        OnPuzzleSolved += Self_PuzzleSolved;
    }

    private void Start() {
        if (autoStart) {
            OnPuzzleStart?.Invoke(this, EventArgs.Empty);
        }
    }

    private void PuzzleObjective_OnObjectiveStatusChange(object sender, bool status) {
        if (status) CheckPuzzleSolved();
    }

    private void CheckPuzzleSolved() {
        foreach (PuzzleObjective objective in _puzzleObjectives) {
            if (!objective.IsObjectiveCompleted()) {
                return;
            }
        }
        OnPuzzleSolved?.Invoke(this, EventArgs.Empty);
    }

    private void Self_PuzzleSolved(object sender, EventArgs e)
    {
        Debug.Log("Puzzle Solved");
    }

    private void Self_PuzzleStarted(object sender, EventArgs e)
    {
        Debug.Log("Puzzle Started");
    }
}
