using System;
using UnityEngine;
using Zenject;

public class ImporterDialogSystemCallAudioManager : IDisposable, IInitializable
{
    private DialogSystemCall _dialogSystemCall;
    private AudioManager _audioManager;

    public ImporterDialogSystemCallAudioManager(DialogSystemCall dialogSystemCall, AudioManager audioManager)
    {
        _dialogSystemCall = dialogSystemCall;
        _audioManager = audioManager;
    }

    public void Initialize()
    {
        _dialogSystemCall.OnStateDialog += OnStateDialog;
    }

    public void Dispose()
    {
        _dialogSystemCall.OnStateDialog -= OnStateDialog;
    }

    private void OnStateDialog(bool isActive)
    {
        _audioManager.PlayPhoneInstall(isActive);
    }

}