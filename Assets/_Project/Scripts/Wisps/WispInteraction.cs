using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WispInteraction : InteractionByTrigger
{
    [SerializeField]
    private int addIntensity;
    public static Action<int> AddLightIntensity;
    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.CompareTag("Player"))
    //     {
    //         Interact();
    //     }
    // }

    public string GetName()
    {
        return"Wisp Interaction";
    }

    public override void Interact()
    {
        Debug.Log(GetName());
        AddLightIntensity?.Invoke(addIntensity);
        Destroy(this.gameObject);
    }
}
