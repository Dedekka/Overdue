using UnityEngine;

public class EventInputSystem
{
    private PauseSystem _pause;
    private PlayerUi _playerUi;
    private LookItemRotate _lookItemRotate;
    private LookItemCamera _lookItemCamera;
    private PlayerLookItem _playerLookItem;

    public EventInputSystem(PlayerUi playerUi, PauseSystem pause, PlayerLookItem playerLookItem)
    {
        _playerUi = playerUi;
        _pause = pause;
        _lookItemRotate = playerLookItem.LookItemRotate;
        _lookItemCamera = playerLookItem.LookItemCamera;
        _playerLookItem = playerLookItem;
    }

    public void InventoryView()
    {
        _playerUi.InventoryView();
    }

    public void Pause()
    {
        if (_playerLookItem.IsActive)
        {
            _playerLookItem.EndLookItem();
        }
        else
        {
            _pause.Pause();
        }
    }

    public void ProcessRotate(Vector2 rotate)
    {
        _lookItemRotate.ProcessRotate(rotate);
    }

    public void ResetLookItemRotate()
    {
        _lookItemRotate.ResetLookItemRotate();
    }

    public void ZoomItem(Vector2 rotate)
    {
        _lookItemCamera.Zoom(rotate);
    }
}