using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WispInteraction : MonoBehaviour
{
    [SerializeField]
    private int addIntensity;
    public static Action<int> IncreaseLight;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            IncreaseLight?.Invoke(addIntensity);
            Destroy(this.gameObject);
        }
    }
}
