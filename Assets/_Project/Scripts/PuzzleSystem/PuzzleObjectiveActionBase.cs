using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleObjectiveActionBase : MonoBehaviour
{
    private PuzzleObjective _puzzleObjective;

    private void OnEnable() {
        PuzzleObjective.OnObjectiveStatusChange += PuzzleObjective_OnObjectiveStatusChange;
    }

    private void OnDisable() {
        PuzzleObjective.OnObjectiveStatusChange -= PuzzleObjective_OnObjectiveStatusChange;
    }

    public void AssingPuzzleObjective(PuzzleObjective puzzleObjective)
   {
      _puzzleObjective = puzzleObjective;
   }

   protected abstract void CompleteFeedback();

   protected abstract void UncompleteFeedback();



    private void PuzzleObjective_OnObjectiveStatusChange(object sender, OnObjectStatusChangeArgs e)
    {
        if (e.puzzleObjective != _puzzleObjective) return;

        if (e.status) {
            CompleteFeedback();
        } else {
            UncompleteFeedback();
        }
    }
}
