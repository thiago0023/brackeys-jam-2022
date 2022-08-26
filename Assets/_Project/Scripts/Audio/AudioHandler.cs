using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioStorage))]
public class AudioHandler : Singleton<AudioHandler>
{
    [SerializeField]
    private AudioSource bgmAudioSource;
    [SerializeField]
    private AudioSource bgsAudioSource;
    [SerializeField]
    private AudioSource sfxAudioSource;
    public AudioStorage audioStorage;

    // TEMP START
    private void Start()
    {
        audioStorage = GetComponent<AudioStorage>();
    }

    public void PlayAudio(enAudioType audioType, string audioName, bool loop = true, AudioSource audioSource = null)
    {
        var audio = audioStorage.GetAudio(audioName).clip;
        if(!audio) return;

        var selectedAudioSource = SelectAudioSource(audioType, audioSource);
        SetAudioClip(selectedAudioSource, audio);
        SetAudioLoop(selectedAudioSource, loop);
        Play(selectedAudioSource);
    }

    private AudioSource SelectAudioSource(enAudioType audioType, AudioSource audioSource)
    {
        if(audioSource != null) return audioSource;
        var newAudioSource = audioSource;

        switch(audioType)
        {
            case enAudioType.BGM:
                newAudioSource = bgmAudioSource;
                break;
            case enAudioType.BGS:
                newAudioSource = bgsAudioSource;
                break;
            case enAudioType.SFX:
                newAudioSource = sfxAudioSource;
                break;
        }
        return newAudioSource;
    }

    private void SetAudioClip(AudioSource audioSource, AudioClip audio)
    {
        audioSource.clip = audio;
    }

    private void SetAudioLoop(AudioSource audioSource, bool loop)
    {
        audioSource.loop = loop;
    }

    private void Play(AudioSource audioSource)
    {
        audioSource.Play();
    }
}
