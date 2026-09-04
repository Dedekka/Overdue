using System;
using UnityEngine;
using Zenject;

public class ControlSensitivity : IInitializable
{
    public float Sensitivity => _controlSettings.Sensitivity;
    private ControlSettings _controlSettings;
    public event Action<float> OnLoadSensitivity;
    public event Action<float> OnChangeSensitivity;

    public ControlSensitivity(ControlSettings controlSettings)
    {
        _controlSettings = controlSettings;
    }

    public void ChangeSensitivity(float sensitivity)
    {
        _controlSettings.ChangeSensitivity(sensitivity);
        OnChangeSensitivity?.Invoke(sensitivity);
    }

    public void Initialize()
    {
        Debug.Log($"ControlSensitivity, Sensitivity:{Sensitivity}");
        OnLoadSensitivity?.Invoke(_controlSettings.Sensitivity);
    }
}
