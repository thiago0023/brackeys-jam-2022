using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleCompleteBase : MonoBehaviour
{
    private PuzzleManager _puzzleManager;
    public void AssignPuzzleManager(PuzzleManager puzzleManager)
    {
        _puzzleManager = puzzleManager;
    }

    private void OnEnable() {
        PuzzleManager.OnPuzzleSolved += PuzzleManager_OnPuzzleSolved;
    }

    private void OnDisable() {
        PuzzleManager.OnPuzzleSolved -= PuzzleManager_OnPuzzleSolved;
    }

    private void PuzzleManager_OnPuzzleSolved (object sender, PuzzleManager puzzleManager)
    {
        if (puzzleManager == _puzzleManager) {
            CompletePuzzle();
        }
    }

    protected abstract void CompletePuzzle();
}
