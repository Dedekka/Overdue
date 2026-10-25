using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class MenuInputControl : IDisposable, IInitializable //, ITickable 
{
    private GamePadSelecter _gamePadSelecter;
    private PlayerSystemActions.UIActions _uiActions;

    public event Action<InputDevice> OnChangeDevice;

    public MenuInputControl(PlayerSystemActions inputActions, GamePadSelecter gamePadSelecter)
    {
        _uiActions = inputActions.UI;
        _gamePadSelecter = gamePadSelecter;
    }

    public void Dispose()
    {
        InputSystem.onActionChange -= InputSystem_onActionChange;
        _uiActions.RightLeft.started -= OnRightLeft;

        _uiActions.Disable();
    }


    public void Initialize()
    {
        _uiActions.Enable();
        _uiActions.RightLeft.started += OnRightLeft;
        InputSystem.onActionChange += InputSystem_onActionChange;
    }

    private void OnRightLeft(InputAction.CallbackContext CallbackContext)
    {
        float direction = CallbackContext.ReadValue<float>();
        _gamePadSelecter.ChangePanel(direction);
        Debug.Log($"OnRightLeft:{direction}");
    }

    private void InputSystem_onActionChange(object obj, InputActionChange change)
    {
        if (change != InputActionChange.ActionStarted) return;

        var action = obj as InputAction;
        if (action == null || action.activeControl == null) return;

        OnChangeDevice?.Invoke(action.activeControl.device);
    }
}