using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : AudioStorage
{
    [SerializeField]
    private AudioSource bgmAudioSource;
    [SerializeField]
    private AudioSource bgsAudioSource;
    [SerializeField]
    private AudioSource sfxAudioSource;

    // TEMP START
    private void Start()
    {
        PlayBGM("Player De");
    }

    public void PlayBGM(string audioName, bool loop = true)
    {
        var audio = GetAudio(audioName).clip;
        if(!audio) return;

        bgmAudioSource.clip = audio;
        bgmAudioSource.Play();
    }

    public void PlayBGS(string audioName, bool loop = true)
    {
        var audio = GetAudio(audioName).clip;
        if(!audio) return;

        bgsAudioSource.clip = audio;
        bgsAudioSource.Play();
    }
    
    public void PlayBGS(string audioName, AudioSource _audioSource, bool loop = true)
    {
        var audio = GetAudio(audioName).clip;
        if(!audio) return;

        _audioSource.clip = audio;
        _audioSource.Play();
    }

    public void PlaySFX(string audioName)
    {
        var audio = GetAudio(audioName).clip;
        if(!audio) return;

        sfxAudioSource.clip = audio;
        sfxAudioSource.Play();
    }
    
    public void PlaySFX(string audioName, AudioSource _audioSource)
    {
        var audio = GetAudio(audioName).clip;
        if(!audio) return;

        _audioSource.clip = audio;
        _audioSource.Play();
    }
}
