using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispStand_Feedback : PuzzleObjectiveActionBase
{
    [SerializeField] private GameObject wisp;

    public void PlaceWisp (bool place) => wisp.SetActive(place);

    protected override void CompleteFeedback() {
        PlaceWisp(true);
    }

    protected override void UncompleteFeedback() {
        PlaceWisp(false);
    }
}
