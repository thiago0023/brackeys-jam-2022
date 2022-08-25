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

    public void Play(string audioType, string audioName, bool loop = true, AudioSource _audioSource = null)
    {
        var audio = audioStorage.GetAudio(audioName).clip;
        if(!audio) return;


    }

    private AudioSource SelectAudioSource(string audioType, AudioSource _audioSource)
    {
        var newAudioSource = _audioSource;

        if(_audioSource != null) return _audioSource;

        switch(audioType)
        {
            case "BGM":
                newAudioSource = bgmAudioSource;
                break;
            case "BGS":
                newAudioSource = bgsAudioSource;
                break;
            case "SFX":
                newAudioSource = sfxAudioSource;
                break;
        }

        return newAudioSource;
    }


    public void PlayBGM(string audioName, bool loop = true)
    {
        var audio = audioStorage.GetAudio(audioName).clip;
        if(!audio) return;

        bgmAudioSource.clip = audio;
        bgmAudioSource.loop = loop;
        bgmAudioSource.Play();
    }

    public void PlayBGS(string audioName, bool loop = true)
    {
        var audio = audioStorage.GetAudio(audioName).clip;
        if(!audio) return;

        bgsAudioSource.clip = audio;
        bgsAudioSource.loop = loop;
        bgsAudioSource.Play();
    }
    
    public void PlayBGS(string audioName, AudioSource _audioSource, bool loop = true)
    {
        var audio = audioStorage.GetAudio(audioName).clip;
        if(!audio) return;

        _audioSource.clip = audio;
        _audioSource.loop = loop;
        _audioSource.Play();
    }

    public void PlaySFX(string audioName)
    {
        var audio = audioStorage.GetAudio(audioName).clip;
        if(!audio) return;

        sfxAudioSource.clip = audio;
        sfxAudioSource.Play();
    }
    
    public void PlaySFX(string audioName, AudioSource _audioSource)
    {
        var audio = audioStorage.GetAudio(audioName).clip;
        if(!audio) return;

        _audioSource.clip = audio;
        _audioSource.Play();
    }
}
