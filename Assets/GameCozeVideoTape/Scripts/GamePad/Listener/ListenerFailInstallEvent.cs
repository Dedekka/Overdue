using System;
using Zenject;

public class ListenerFailInstallEvent : IDisposable, IInitializable
{
    private ImporterMenuInputControlDevice _importerMenuInputControlDevice;
    private ListenerFailInstallCassete _listenerFailInstallCassete;
    private ControlGamepadVibration _controlGamepadVibration;

    public ListenerFailInstallEvent(ListenerFailInstallCassete listenerFailInstallCassete, ControlGamepadVibration controlGamepadVibration, ImporterMenuInputControlDevice importerMenuInputControlDevice)
    {
        _listenerFailInstallCassete = listenerFailInstallCassete;
        _controlGamepadVibration = controlGamepadVibration;
        _importerMenuInputControlDevice = importerMenuInputControlDevice;
    }

    public void Initialize()
    {
        _listenerFailInstallCassete.OnStateInstall += OnComplited;
    }

    public void Dispose()
    {
        _listenerFailInstallCassete.OnStateInstall -= OnComplited;
    }

    private void OnComplited(bool isState)
    {
        if (_importerMenuInputControlDevice.CurrentDevice == DeviceType.Gamepad)
        {
            _controlGamepadVibration.ActiveVibrationInstall(isState);
        }
        else
        {
            _controlGamepadVibration.ResetVibration();
        }
    }
}