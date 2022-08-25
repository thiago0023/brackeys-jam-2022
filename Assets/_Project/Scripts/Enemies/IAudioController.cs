using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioController
{
    [SerializeField]
    private List<string> audioList;
    [SerializeField]
    private AudioSource audioSource;
    private bool audioSourceFound = false;

    private PlayAudioDefault();
    private PlayAudioDead();
}
