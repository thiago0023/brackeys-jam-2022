using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSettings : MonoBehaviour
{
    [SerializeField]
    protected List<string> audioList;
    [SerializeField]
    protected AudioSource audioSource;
    protected bool audioSourceFound = false;

    protected virtual void Start()
    {
        if (TryGetComponent<AudioSource>(out AudioSource component))
        {
            audioSource = component;
            audioSourceFound = true;
        }
    }
}
