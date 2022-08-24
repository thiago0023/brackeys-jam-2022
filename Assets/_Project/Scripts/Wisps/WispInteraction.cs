using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WispInteraction : MonoBehaviour
{
    [SerializeField]
    private int addIntensity;
    public static Action<int> AddLightIntensity;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AddLightIntensity?.Invoke(addIntensity);
            Destroy(this.gameObject);
        }
    }
}
