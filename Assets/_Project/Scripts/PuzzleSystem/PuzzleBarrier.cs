using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBarrier : PuzzleCompleteBase
{
    [SerializeField] private float moveModifier;
    [SerializeField] private float actionDuration = 1f;
    protected override void CompletePuzzle()
    {
        var destination = transform.position + transform.forward * moveModifier;
        StartCoroutine(MoveBarrier(destination));
    }

    private IEnumerator MoveBarrier(Vector3 destination){
        var currentPosition = transform.position;
        while (Vector3.Distance(currentPosition, destination) > 0.1f) {
            currentPosition = Vector3.Lerp(currentPosition, destination, Time.deltaTime / actionDuration);
            transform.position = currentPosition;
            yield return null;
        }
    }
}
