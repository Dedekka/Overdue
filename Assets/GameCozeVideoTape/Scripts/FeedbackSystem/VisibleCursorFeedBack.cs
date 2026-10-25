using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.XInput;
using Zenject;

public class VisibleCursorFeedBack : IDisposable, IInitializable
{
    public DeviceType CurrentDevice { get; private set; }
    private PlayerSystemActions.UIActions _uiActions;

    public event Action<InputDevice> OnChangeDevice;

    private bool _isVisibleState;

    public VisibleCursorFeedBack(PlayerSystemActions inputActions )
    {
        _uiActions = inputActions.UI;
    }

    public void Dispose()
    {
        InputSystem.onActionChange -= InputSystem_onActionChange;

        OnChangeDevice -= ChangeDevice;
        _uiActions.Disable();
    }


    public void Initialize()
    {
        _uiActions.Enable();
        SetVisibleState(true);
        InputSystem.onActionChange += InputSystem_onActionChange;
        OnChangeDevice += ChangeDevice;
    }

    public void SetVisibleState(bool isVisible)
    {
        _isVisibleState = isVisible;
    }

    private void InputSystem_onActionChange(object obj, InputActionChange change)
    {
        if (change != InputActionChange.ActionStarted) return;

        var action = obj as InputAction;
        if (action == null || action.activeControl == null) return;

        OnChangeDevice?.Invoke(action.activeControl.device);
    }

    private void ChangeDevice(UnityEngine.InputSystem.InputDevice device)
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
            //OnChangeDevice?.Invoke(CurrentDevice);
        }
        ChangeDevice(CurrentDevice);
        //OnInputDevice?.Invoke(CurrentDevice);
    }


    private void CheckVisibleCursor()
    {
        //if (_isVisibleState)
        //{
        if (CurrentDevice == DeviceType.KeyboardMouse)
        {
            Debug.Log("CheckVisibleCursor, Переключение на клавиатуру/мышь");
            ControlVisible(CursorLockMode.None);
            //Cursor.lockState = CursorLockMode.None;
            return;
        }
        //}
        Debug.Log("CheckVisibleCursor, Переключение на геймпад");
        ControlVisible(CursorLockMode.Locked);
        //Cursor.lockState = CursorLockMode.Locked;
    }


    private void ChangeDevice(DeviceType obj)
    {
        CheckVisibleCursor();
    }

    private void ControlVisible(CursorLockMode cursorLock)
    {
        if (Cursor.lockState == cursorLock) { return; }

        Cursor.lockState = _isVisibleState ? cursorLock : CursorLockMode.Locked;
    }

}
