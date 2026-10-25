using System;
using UnityEngine;
using Zenject;

public class ImporterDeviceGamePadVisibleUi : IDisposable, IInitializable
{
    private GamePadVisibleUi _gamePadVisibleUi;
    private ControlGamePadVisible _controlGamePadVisible;
    private ImporterMenuInputControlDevice _importerMenuInputControlDevice;

    public ImporterDeviceGamePadVisibleUi(ImporterMenuInputControlDevice importerMenuInputControlDevice, GamePadVisibleUi gamePadVisibleUi, ControlGamePadVisible controlGamePadVisible)
    {
        _importerMenuInputControlDevice = importerMenuInputControlDevice;
        _gamePadVisibleUi = gamePadVisibleUi;
        _controlGamePadVisible = controlGamePadVisible;
    }

    public void Dispose()
    {
        _importerMenuInputControlDevice.OnInputDevice -= OnChangeDevice;
    }

    public void Initialize()
    {
        _importerMenuInputControlDevice.OnInputDevice += OnChangeDevice;
    }

    private void OnChangeDevice(DeviceType deviceType)
    {
        if (deviceType == DeviceType.KeyboardMouse)
        {
            _gamePadVisibleUi.ControlVisibleGamePadUi(false);
        }
        else if (deviceType == DeviceType.Gamepad || deviceType == DeviceType.GamepadXbox || deviceType == DeviceType.GamepadSony)
        {
            _gamePadVisibleUi.ControlVisibleGamePadUi(true);
            _controlGamePadVisible.OnChangeDevice(deviceType);
        }

        //if (deviceType == DeviceType.KeyboardMouse && Time.timeScale > 0)
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
        //else
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //}
    }
}