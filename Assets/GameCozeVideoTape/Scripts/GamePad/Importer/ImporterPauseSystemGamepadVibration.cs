using System;
using UnityEngine;
using Zenject;

public class ImporterPauseSystemGamepadVibration : IDisposable, IInitializable
{
    private ControlGamepadVibration _controlGamepadVibration;
    private PauseSystem _pauseSystem;

    public ImporterPauseSystemGamepadVibration(ControlGamepadVibration controlGamepadVibration, PauseSystem pauseSystem)
    {
        _controlGamepadVibration = controlGamepadVibration;
        _pauseSystem = pauseSystem;
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
        _controlGamepadVibration.PauseVibration(isPause);
    }
}