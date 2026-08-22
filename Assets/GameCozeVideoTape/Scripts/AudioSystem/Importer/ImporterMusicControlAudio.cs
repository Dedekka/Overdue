using System;
using UnityEngine;
using Zenject;

public class ImporterMusicControlAudio : IDisposable, IInitializable
{
    private MusicControl _musicControl;
    private AudioManager _audioManager;

    public ImporterMusicControlAudio(MusicControl musicControl, AudioManager audioManager)
    {
        _musicControl = musicControl;
        _audioManager = audioManager;
    }

    public void Dispose()
    {
        _musicControl.OnChangeMusic -= OnChangeMusic;
        _musicControl.OnChangeState -= OnChangeState;
    }

    public void Initialize()
    {
        _musicControl.OnChangeMusic += OnChangeMusic;
        _musicControl.OnChangeState += OnChangeState; 
    }

    private void OnChangeState(bool _isPlaying)
    {
        Debug.Log("OnChangeState");
        _audioManager.PlayMusic(_isPlaying);
    }

    private void OnChangeMusic(FMODUnity.EventReference eventReference)
    {
        Debug.Log("OnChangeMusic");
        _audioManager.SetMusic(eventReference);
    }
}