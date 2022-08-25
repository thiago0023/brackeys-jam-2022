using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private PuzzleObjective[] _puzzleObjectives;
    public event EventHandler OnPuzzleStart;
    public event EventHandler OnPuzzleValidate;
    public event EventHandler OnPuzzleSolved;

    
}
