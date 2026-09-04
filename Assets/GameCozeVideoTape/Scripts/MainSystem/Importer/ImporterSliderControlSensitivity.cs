using System;
using UnityEngine.UI;
using Zenject;

public class ImporterSliderControlSensitivity : IInitializable, IDisposable
{
    private Slider _sliderSensitivity;
    private ControlSensitivity _controlSensitivity;

    public ImporterSliderControlSensitivity(Slider sliderSensitivity, ControlSensitivity controlSensitivity)
    {
        _sliderSensitivity = sliderSensitivity;
        _controlSensitivity = controlSensitivity;
    }

    public void Dispose()
    {
        _controlSensitivity.OnLoadSensitivity -= OnLoadSensitivity;
    }

    public void Initialize()
    {
        _controlSensitivity.OnLoadSensitivity += OnLoadSensitivity;
        _sliderSensitivity.onValueChanged.AddListener(_controlSensitivity.ChangeSensitivity);
    }

    private void OnLoadSensitivity(float sensitivity)
    {
        _sliderSensitivity.value = sensitivity;
    }
}