using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective_PuzzleBarrier : PuzzleObjectiveActionBase
{
    [SerializeField] private float moveModifier;
    [SerializeField] private float actionDuration = 1f;

    private Vector3 originalPosition;

    private void Awake() {
        originalPosition = transform.position;
    }

    protected override void CompleteFeedback()
    {
        StartMovementForward();
    }

    protected void StartMovementForward()
    {
        var destination = transform.position + transform.forward * moveModifier;
        StopCoroutine(nameof(MoveBarrier));
        StartCoroutine(MoveBarrier(destination));
    }

    protected void StartMovementBackward()
    {
        var destination = transform.position + transform.forward * moveModifier * -1;
        StopCoroutine(nameof(MoveBarrier));
        StartCoroutine(MoveBarrier(originalPosition));
    }

    protected override void UncompleteFeedback()
    {
        StartMovementBackward();
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
