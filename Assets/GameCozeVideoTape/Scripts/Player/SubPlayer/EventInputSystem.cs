using UnityEngine;

public class EventInputSystem
{
    private PauseSystem _pause;
    private PlayerUi _playerUi;
    private LookItemRotate _lookItemRotate;
    private LookItemCamera _lookItemCamera;
    private PlayerLookItem _playerLookItem;
    private ControlFullScreenTutorial _controlFullScreenTutorial;

    public EventInputSystem(PlayerUi playerUi, PauseSystem pause, PlayerLookItem playerLookItem, ControlFullScreenTutorial controlFullScreenTutorial)
    {
        _playerUi = playerUi;
        _pause = pause;
        _lookItemRotate = playerLookItem.LookItemRotate;
        _lookItemCamera = playerLookItem.LookItemCamera;
        _playerLookItem = playerLookItem;
        _controlFullScreenTutorial = controlFullScreenTutorial;
    }

    public void InventoryView()
    {
        _playerUi.InventoryShow();
    }

    public void Pause()
    {
        if (!ControllPauseState())
        {
            _pause.Pause();
        }
    }

    public void EndPause()
    {
        if (!ControllPauseState())
        {
            _pause.Pause(false);
        }
    }

    public void EndLookItem()
    {
        if (_playerLookItem.IsActive)
        {
            _playerLookItem.EndLookItem();
        }
    }

    public void EndFullScreenTutorial()
    {
        if (_controlFullScreenTutorial.IsActive)
        {
            _controlFullScreenTutorial.ControlActive(false);
        }
    }


    public void ProcessRotate(Vector2 rotate, DeviceType deviceType)
    {
        if (_playerLookItem.IsActive)
        {
            _lookItemRotate.ProcessRotate(rotate, deviceType);
        }
    }

    public void ResetLookItemRotate()
    {
        if (_playerLookItem.IsActive)
        {
            _lookItemRotate.ResetLookItemRotate();
        }
    }

    public void ZoomItem(Vector2 rotate)
    {
        if (_playerLookItem.IsActive)
        {
            _lookItemCamera.Zoom(-rotate);
        }
    }

    public bool ControllClosePanelState()
    {
        bool _isActivePause = false;

        if (_pause.IsPause)
        {
            _isActivePause = true;
        }
        if (ControllPauseState())
        {
            _isActivePause = true;

        }
        return _isActivePause;
    }

    private bool ControllPauseState()
    {
        bool _isActivePause = false;

        if (_playerLookItem.IsActive)
        {
            _isActivePause = true;
        }
        if (_controlFullScreenTutorial.IsActive)
        {
            _isActivePause = true;
        }
        return _isActivePause;
    }

 
}