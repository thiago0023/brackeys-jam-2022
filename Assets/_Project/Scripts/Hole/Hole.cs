using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerActions.KillPlayer?.Invoke();
    }
}
