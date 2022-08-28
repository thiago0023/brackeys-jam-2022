using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveFeedback : InteractionByTrigger
{

    [SerializeField] private GameObject _feedback;
    public override void BeginInteraction()
    {
        throw new System.NotImplementedException();
    }

    public override void EndInteraction()
    {
        _feedback.SetActive(false);
    }

    public override void Interact()
    {
        _feedback.SetActive(true);
    }
}
