using System;
using UnityEngine;
using Zenject;

public class ImporterTVAudioManager : IDisposable, IInitializable
{
    private TV _tv;
    private AudioManager _audioManager;

    public ImporterTVAudioManager(TV tv, AudioManager audioManager)
    {
        _tv = tv;
        _audioManager = audioManager;
    }

    public void Dispose()
    {
        _tv.OnStateInstallTv -= OnStateInstallTv;
    }

    public void Initialize()
    {
        _tv.OnStateInstallTv += OnStateInstallTv;
    }

    private void OnStateInstallTv(bool isInstall)
    {
        _audioManager.PlayTvInstall(isInstall);
    }
}
