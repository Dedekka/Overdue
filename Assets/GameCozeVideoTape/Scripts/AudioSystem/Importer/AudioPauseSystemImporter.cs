using System;
using UnityEngine;
using Zenject;

public class AudioPauseSystemImporter : IDisposable, IInitializable
{
    private PauseSystem _pauseSystem;
    private AudioManager _audioManager;

    public AudioPauseSystemImporter(PauseSystem pauseSystem, AudioManager audioManager)
    {
        _pauseSystem = pauseSystem;
        _audioManager = audioManager;
    }

    public void Dispose()
    {
        _pauseSystem.OnChangeStatePause -= OnChangeStatePause;
    }

    public void Initialize()
    {
        _pauseSystem.OnChangeStatePause += OnChangeStatePause;
    }

    private void OnChangeStatePause(bool isPause)
    {
        _audioManager.PauseVoise(isPause);
    }
}