using System;
using UnityEngine.InputSystem;
using Zenject;

public class ListenerPresentEvent : IDisposable, IInitializable
{
    private ImporterMenuInputControlDevice _importerMenuInputControlDevice;
    private PresentEventManager _presentEventManager;
    private ControlGamepadVibration _controlGamepadVibration;

    public ListenerPresentEvent(PresentEventManager presentEventManager, ControlGamepadVibration controlGamepadVibration, ImporterMenuInputControlDevice importerMenuInputControlDevice)
    {
        _presentEventManager = presentEventManager;
        _controlGamepadVibration = controlGamepadVibration;
        _importerMenuInputControlDevice = importerMenuInputControlDevice;
    }

    public void Initialize()
    {
        _presentEventManager.OnEventComplited += OnEventComplited;
    }

    public void Dispose()
    {
        _presentEventManager.OnEventComplited -= OnEventComplited;
    }

    private void OnEventComplited()
    {
        if (_importerMenuInputControlDevice.CurrentDevice == DeviceType.Gamepad)
        {
            _controlGamepadVibration.ActiveVibrationPresent();
        }
    }
}