using System;
using Zenject;
using UnityEngine;

public class ImporterRecorderAnimationMusicControl : IDisposable, IInitializable
{
    private AudioRecorderAnimation _audioRecorder;
    private MusicControl _musicControl;

    public ImporterRecorderAnimationMusicControl(AudioRecorderAnimation audioRecorder, MusicControl musicControl )
    {
        _audioRecorder = audioRecorder;
        _musicControl = musicControl;
    }

    public void Dispose()
    {
        _musicControl.OnChangeState -= OnChangeStateButtonPlay;
    }

    public void Initialize()
    {
        _musicControl.OnChangeState += OnChangeStateButtonPlay;
    }

    private void OnChangeStateButtonPlay(bool isplay)
    {
        _audioRecorder.ChangeStateButtonPlay(isplay);
    }
}