using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ImporterSliderControlSensitivity : IInitializable, IDisposable
{
    private Slider _sliderSensitivity;
    private ControlSensitivity _controlSensitivity;
    private SettingsPlayer _settingsPlayer;

    public ImporterSliderControlSensitivity(Slider sliderSensitivity, ControlSensitivity controlSensitivity, SettingsPlayer settingsPlayer)
    {
        _sliderSensitivity = sliderSensitivity;
        _controlSensitivity = controlSensitivity;
        _settingsPlayer = settingsPlayer;
    }

    public void Dispose()
    {
        _controlSensitivity.OnLoadSensitivity -= OnLoadSensitivity;
    }

    public void Initialize()
    {
        Vector2 rangeSlider = _settingsPlayer.RangeSliderSensitivity;
        _sliderSensitivity.minValue = rangeSlider.x;
        _sliderSensitivity.maxValue = rangeSlider.y;

        _controlSensitivity.OnLoadSensitivity += OnLoadSensitivity;
        _sliderSensitivity.onValueChanged.AddListener(_controlSensitivity.ChangeSensitivity);
    }

    private void OnLoadSensitivity(float sensitivity)
    {
        _sliderSensitivity.value = sensitivity;
    }
}