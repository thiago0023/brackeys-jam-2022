using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBarrierSpin : PuzzleCompleteBase
{
    [SerializeField] private float angleModifier;
    [SerializeField] private float actionDuration = 1f;
    protected override void CompletePuzzle()
    {
        var finishAngle = transform.rotation.eulerAngles.y + angleModifier;
        StartCoroutine(MoveBarrier(finishAngle));
    }

    private IEnumerator MoveBarrier(float addAngle){
        var currentAngle = transform.rotation.eulerAngles.y;
        while (currentAngle - addAngle > 0.1f) {
            currentAngle = Mathf.Lerp(currentAngle, addAngle, Time.deltaTime / actionDuration);
            transform.Rotate(transform.rotation.eulerAngles.x, currentAngle, transform.rotation.eulerAngles.z);
            yield return null;
        }
    }

}
