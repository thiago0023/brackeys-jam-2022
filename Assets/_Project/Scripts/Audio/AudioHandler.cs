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
    [SerializeField]
    private AudioSettings audioSettings;
    private AudioStorage audioStorage;

    // TEMP START
    private void Awake()
    {
        audioStorage = GetComponent<AudioStorage>();
        PlayAudio(audioSettings.audioType, audioSettings.audioName);
    }

    public void PlayAudio(enAudioType audioType, string audioName, bool loop = true, AudioSource audioSource = null)
    {
        var audio = audioStorage.GetAudio(audioName).clip;
        if(!audio) return;

        print("type: " + audioType);
        print("name: " + audioName);
        print("loop: " + loop);
        print("source: " + audioSource);

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
