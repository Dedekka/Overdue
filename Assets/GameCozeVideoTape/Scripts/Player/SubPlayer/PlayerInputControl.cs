using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInputControl : IDisposable, IInitializable, ITickable // ILateTickable,
{
    private EventInputSystem _eventInputSystem;
    private PauseSystem _pause;
    private PlayerMove _playerMover;
    private PlayerLook _playerLook;
    private PlayerAim _playerAim;
    private PlayerInteracteble _playerInteracteble;
    private PlayerInventory _playerInventory;
    private PlayerSystemActions.PlayerActions _playerActions;
    private bool _isPause;

    public PlayerInputControl(Player testPlayerCharacter, PlayerSystemActions inputActions, PlayerInteracteble testPlayerInteracteble, PlayerInventory playerInventory, PauseSystem pauseSystem, EventInputSystem eventInputSystem)//, TestWeaponSystem testWeaponSystem, SystemBuss systemBuss)
    {
        _pause = pauseSystem;
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
        _isPause = false;
        _playerActions.Aim.started += AimControl;
        _playerActions.Aim.canceled += AimControl;
        _playerActions.Interact.started += OnInteracteble;
        _playerActions.Drop.started += OnDrop;
        _playerActions.Scroll.started += OnScroll;
        _playerActions.Pause.started += OnPause;
        _playerActions.Inventory.started += OnInventory;
        //_playerActions.Pause.started += OnPause;
    }

    public void Tick()
    {
        if (_isPause) { return; }
        _playerMover.ProcessMove(_playerActions.Move.ReadValue<Vector2>());

        if (_isPause) { return; }
        _playerLook.ProcessLook(_playerActions.Look.ReadValue<Vector2>());
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _isPause = _pause.Pause();
        }
    }

    private void OnInventory(InputAction.CallbackContext context)
    {
        if (_isPause) { return; }
        if (context.phase == InputActionPhase.Started)
        {
            _eventInputSystem.InventoryView();
        }
    }


    private void OnInteracteble(InputAction.CallbackContext context)
    {
        if (_isPause) { return; }
        if (context.phase == InputActionPhase.Started)
        {
            _playerInteracteble.OnInteracteble();
        }
    }

    private void OnDrop(InputAction.CallbackContext context)
    {
        if (_isPause) { return; }
        if (context.phase == InputActionPhase.Started)
        {
            _playerInventory.Drop();
        }
    }

    private void OnScroll(InputAction.CallbackContext context)
    {
        if (_isPause) { return; }
        if (context.phase == InputActionPhase.Started)
        {
            _playerInventory.Scroll(context.ReadValue<Vector2>());
        }
    }

    private void AimControl(InputAction.CallbackContext context)
    {
        if (_isPause) { return; }
        if (context.phase == InputActionPhase.Started)
        {
            _playerAim.ProcessAim(true);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            _playerAim.ProcessAim(false);
        }
    }
}