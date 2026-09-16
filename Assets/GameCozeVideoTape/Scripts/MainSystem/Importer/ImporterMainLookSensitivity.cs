using System;
using UnityEngine;
using Zenject;

public class ImporterMainLookSensitivity : IDisposable, IInitializable
{
    private PlayerLook _playerLook;
    private ControlSensitivity _controlSensitivity;

    public ImporterMainLookSensitivity(PlayerLook playerLook, ControlSensitivity controlSensitivity)
    {
        _playerLook = playerLook;
        _controlSensitivity = controlSensitivity;
    }

    public void Dispose()
    {
        _controlSensitivity.OnChangeSensitivity -= ChangeSensitivity;
        _controlSensitivity.OnLoadSensitivity -= ChangeSensitivity;
    }

    public void Initialize()
    {
        Debug.Log($"ImporterMainLookSensitivity, Sensitivity:{_controlSensitivity.Sensitivity}");
        ChangeSensitivity(_controlSensitivity.Sensitivity);
        _controlSensitivity.OnChangeSensitivity += ChangeSensitivity;
        _controlSensitivity.OnLoadSensitivity += ChangeSensitivity;
    }

    private void ChangeSensitivity(float coefficientSpeed)
    {
        Debug.Log($"ImporterMainLookSensitivity, coefficientSpeed:{coefficientSpeed}");
        _playerLook.ChangeSensitivity(coefficientSpeed);
    }
}
