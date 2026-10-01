using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInputControl : IDisposable, IInitializable, ITickable // ILateTickable,
{
    public DeviceType CurrentDevice { get; private set; }
    private EventInputSystem _eventInputSystem;

    private PlayerMove _playerMover;
    private PlayerLook _playerLook;
    private PlayerAim _playerAim;
    private PlayerInteracteble _playerInteracteble;
    private PlayerInventory _playerInventory;
    private PlayerSystemActions.PlayerActions _playerActions;


    private bool _isPlayerControlON;

    public PlayerInputControl(Player testPlayerCharacter, PlayerSystemActions inputActions, PlayerInteracteble testPlayerInteracteble, PlayerInventory playerInventory, EventInputSystem eventInputSystem)//, TestWeaponSystem testWeaponSystem, SystemBuss systemBuss)
    {
        _playerInteracteble = testPlayerInteracteble;
        _playerMover = testPlayerCharacter.PlayerMove;
        _playerLook = testPlayerCharacter.PlayerLook;
        _playerAim = testPlayerCharacter.PlayerAim;
        _playerActions = inputActions.Player;
        _playerInventory = playerInventory;
        _eventInputSystem = eventInputSystem;
    }

    public void Dispose()
    {
        InputSystem.onActionChange -= InputSystem_onActionChange;
        _playerActions.Aim.started -= AimControl;
        _playerActions.Aim.canceled -= AimControl;
        _playerActions.Interact.started -= OnInteracteble;
        _playerActions.Drop.started -= OnDrop;
        _playerActions.Scroll.started -= OnScroll;
        _playerActions.Inventory.started -= OnInventory;
        _playerActions.Disable();
    }


    public void Initialize()
    {
        _playerActions.Enable();
        _isPlayerControlON = true;
        InputSystem.onActionChange += InputSystem_onActionChange;
        _playerActions.Aim.started += AimControl;
        _playerActions.Aim.canceled += AimControl;
        _playerActions.Interact.started += OnInteracteble;
        _playerActions.Drop.started += OnDrop;
        _playerActions.Scroll.started += OnScroll;
        _playerActions.Pause.started += OnPause;
        _playerActions.Inventory.started += OnInventory;
        _playerActions.ResetLookItemRotate.started += OnResetLookItemRotate;
    }




    public void ChangePlayerControl(bool _isControlON)
    {
        _isPlayerControlON = _isControlON;
    }

    public void Tick()
    {
        //_playerActions.Scroll.

        _eventInputSystem.ZoomItem(_playerActions.Scroll.ReadValue<Vector2>());

        Vector2 inputLook = _playerActions.Look.ReadValue<Vector2>();
        _eventInputSystem.ProcessRotate(inputLook, CurrentDevice);
        if (!_isPlayerControlON) { return; }

        Vector2 inputMove = _playerActions.Move.ReadValue<Vector2>();
        _playerMover.ProcessMove(inputMove);
        if (!_isPlayerControlON) { return; }
        _playerLook.ProcessLook(inputLook, CurrentDevice);

    }

    private void OnResetLookItemRotate(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _eventInputSystem.ResetLookItemRotate();
        }
    }

    //private void OnZoomItem(InputAction.CallbackContext context)
    //{
    //        _eventInputSystem.ZoomItem(context.ReadValue<Vector2>());
    //}

    private void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _eventInputSystem.Pause();
            _eventInputSystem.EndLookItem();

        }
    }

    private void OnInventory(InputAction.CallbackContext context)
    {
        if (!_isPlayerControlON) { return; }
        if (context.phase == InputActionPhase.Started)
        {
            _eventInputSystem.InventoryView();
        }
    }


    private void OnInteracteble(InputAction.CallbackContext context)
    {
        if (!_isPlayerControlON) { return; }
        if (context.phase == InputActionPhase.Started)
        {
            _playerInteracteble.OnInteracteble();
        }
    }

    private void OnDrop(InputAction.CallbackContext context)
    {
        _eventInputSystem.EndLookItem();
        if (!_isPlayerControlON) { return; }
        if (context.phase == InputActionPhase.Started)
        {
            _playerInventory.Drop();
        }
    }

    private void OnScroll(InputAction.CallbackContext context)
    {
        if (!_isPlayerControlON) { return; }
        if (context.phase == InputActionPhase.Started)
        {
            _playerInventory.Scroll(context.ReadValue<Vector2>());
        }
    }

    private void AimControl(InputAction.CallbackContext context)
    {
        if (!_isPlayerControlON) { return; }
        if (context.phase == InputActionPhase.Started)
        {
            _playerAim.ProcessAim(true);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            _playerAim.ProcessAim(false);
        }
    }

    private void InputSystem_onActionChange(object obj, InputActionChange change)
    {
        if (change != InputActionChange.ActionStarted) return;

        var action = obj as InputAction;
        if (action == null || action.activeControl == null) return;

        var device = action.activeControl.device;

        if (device is Gamepad)
        {
            if (CurrentDevice != DeviceType.Gamepad)
            {
                CurrentDevice = DeviceType.Gamepad;
                Debug.Log("Переключение на геймпад");
            }
        }
        else if (device is Keyboard || device is Mouse)
        {
            if (CurrentDevice != DeviceType.KeyboardMouse)
            {
                CurrentDevice = DeviceType.KeyboardMouse;
                Debug.Log("Переключение на клавиатуру/мышь");
            }
        }
    }
}

public enum DeviceType
{
    KeyboardMouse,
    Gamepad
}