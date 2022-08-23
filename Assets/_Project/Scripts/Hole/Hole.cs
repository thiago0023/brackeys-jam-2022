using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Hole : MonoBehaviour
{
    public static event Action FallInTheHole;

    private void OnTriggerEnter(Collider other)
    {
        FallInTheHole?.Invoke();
    }
}
