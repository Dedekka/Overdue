using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.XInput;
using Zenject;

public class ImporterMenuInputControlDevice : IDisposable, IInitializable
{
    public DeviceType CurrentDevice { get; private set; }
    private MenuInputControl _menuInputControl;

    public event Action<DeviceType> OnInputDevice;
    public event Action<DeviceType> OnChangeDevice;

    public ImporterMenuInputControlDevice(MenuInputControl menuInputControl)
    {
        _menuInputControl = menuInputControl;
    }

    public void Dispose()
    {
        _menuInputControl.OnChangeDevice -= ChangeDevice;
    }

    public void Initialize()
    {
        _menuInputControl.OnChangeDevice += ChangeDevice;
    }

    private void ChangeDevice(InputDevice device)
    {
        DeviceType tempDevice = CurrentDevice;

        if (device is Gamepad gamepad)
        {
            if (gamepad is XInputController)
            {
                if (CurrentDevice == DeviceType.GamepadXbox) { return; }
                tempDevice = DeviceType.GamepadXbox;

                Debug.Log("Переключение на Xbox gamepad ");
                /* Xbox gamepad */
            }
            else if (gamepad is DualShockGamepad)
            {
                if (CurrentDevice == DeviceType.GamepadSony) { return; }
                tempDevice = DeviceType.GamepadSony;
                Debug.Log("Переключение на PlayStation gamepad ");
                /* PlayStation gamepad */
            }
            else if (CurrentDevice != DeviceType.Gamepad)
            {
                tempDevice = DeviceType.Gamepad;
                Debug.Log("Переключение на геймпад");
            }
        }
        else if (device is Keyboard || device is Mouse)
        {
            if (CurrentDevice != DeviceType.KeyboardMouse)
            {
                tempDevice = DeviceType.KeyboardMouse;
                Debug.Log("Переключение на клавиатуру/мышь");
            }
        }

        if (CurrentDevice != tempDevice)
        {
            CurrentDevice = tempDevice;
            OnChangeDevice?.Invoke(CurrentDevice);
        }

        OnInputDevice?.Invoke(CurrentDevice);
    }

}