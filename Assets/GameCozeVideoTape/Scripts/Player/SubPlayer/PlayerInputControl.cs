using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInputControl : IDisposable, IInitializable, ITickable // ILateTickable,
{
    private PlayerMove _playerMover;
    private PlayerLook _playerLook;
    private PlayerAim _playerAim;
    private PlayerInteracteble _playerInteracteble;
    private PlayerInventory _playerInventory;
    private PlayerSystemActions.PlayerActions _playerActions;
    private bool _isPlayerControl;

    public PlayerInputControl(Player testPlayerCharacter, PlayerSystemActions inputActions, PlayerInteracteble testPlayerInteracteble, PlayerInventory playerInventory)//, TestWeaponSystem testWeaponSystem, SystemBuss systemBuss)
    {
        _playerInteracteble = testPlayerInteracteble;
        _playerMover = testPlayerCharacter.PlayerMove;
        _playerLook = testPlayerCharacter.PlayerLook;
        _playerAim = testPlayerCharacter.PlayerAim;
        _playerActions = inputActions.Player;
        _playerInventory = playerInventory;
    }

    public void Dispose()
    {
        _playerActions.Aim.started -= AimControl;
        _playerActions.Aim.canceled -= AimControl;
        _playerActions.Interact.started -= OnInteracteble;
        _playerActions.Drop.started -= OnDrop;
        _playerActions.Scroll.started -= OnScroll;
        _playerActions.Disable();
    }

    public void Initialize()
    {
        _playerActions.Enable();
        _isPlayerControl = true;
        _playerActions.Aim.started += AimControl;
        _playerActions.Aim.canceled += AimControl;
        _playerActions.Interact.started += OnInteracteble;
        _playerActions.Drop.started += OnDrop;
        _playerActions.Scroll.started += OnScroll;
        //_playerActions.Pause.started += OnPause;
    }

    //private void OnPause(InputAction.CallbackContext context)
    //{
    //    if (context.phase == InputActionPhase.Started)
    //    {
    //        _systemBuss.Pause();
    //    }
    //}

    public void Tick()
    {
        if (!_isPlayerControl) { return; }
        _playerMover.ProcessMove(_playerActions.Move.ReadValue<Vector2>());

        if (!_isPlayerControl) { return; }
        _playerLook.ProcessLook(_playerActions.Look.ReadValue<Vector2>());
    }

    //public void LateTick()
    //{
    //    //if (!_isPlayerControl) { return; }
    //    //_playerLook.ProcessLook(_playerActions.Look.ReadValue<Vector2>());
    //}

    private void OnInteracteble(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _playerInteracteble.OnInteracteble();
        }
    }

    private void OnDrop(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _playerInventory.Drop();
        }
    }

    private void OnScroll(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _playerInventory.Scroll(context.ReadValue<Vector2>());
        }
    }

    private void AimControl(InputAction.CallbackContext context)
    {
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