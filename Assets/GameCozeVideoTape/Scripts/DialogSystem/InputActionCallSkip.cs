using System;
using UnityEngine.InputSystem;
using Zenject;

public class InputActionCallSkip : IDisposable, IInitializable
{
    private PlayerSystemActions.UIActions _uiActions;
    private ControlSkipCall _controlSkipCall;

    public InputActionCallSkip(PlayerSystemActions inputActions, ControlSkipCall controlSkipCall)
    {
        _uiActions = inputActions.UI;
        _controlSkipCall = controlSkipCall;
    }

    public void Initialize()
    {
        _uiActions.Enable();
    }

    public void Dispose()
    {
        _uiActions.CallSkip.performed -= OnCallSkip;
        _uiActions.Disable();
    }

    public void SubCallSkip(bool isSub)
    {
        if (isSub)
        {
            _uiActions.CallSkip.performed += OnCallSkip;
        }
        else
        {
            _uiActions.CallSkip.performed -= OnCallSkip;
        }
    }

    private void OnCallSkip(InputAction.CallbackContext context)
    {
        _controlSkipCall.ActiveSkip();
    }
}