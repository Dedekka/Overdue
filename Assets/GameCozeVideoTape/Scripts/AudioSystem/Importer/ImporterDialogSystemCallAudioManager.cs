using System;
using UnityEngine;
using Zenject;

public class ImporterDialogSystemCallAudioManager : IDisposable, IInitializable
{
    private CutsceneBlackScreen _cutsceneBlackScreen;
    private DialogSystemCall _dialogSystemCall;
    private AudioManager _audioManager;

    public ImporterDialogSystemCallAudioManager(DialogSystemCall dialogSystemCall, AudioManager audioManager, CutsceneBlackScreen cutsceneBlackScreen)
    {
        _dialogSystemCall = dialogSystemCall;
        _audioManager = audioManager;
        _cutsceneBlackScreen = cutsceneBlackScreen;
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
        _cutsceneBlackScreen.ControlView(true);
        _cutsceneBlackScreen.ActiveBlackScreen(0, 2);
        _audioManager.PlayPhoneInstall(isActive);
    }

}