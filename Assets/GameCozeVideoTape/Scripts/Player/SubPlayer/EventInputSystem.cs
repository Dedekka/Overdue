using UnityEngine;

public class EventInputSystem
{
    private PauseSystem _pause;
    private PlayerUi _playerUi;
    private TestMoveItem _testMoveItem;
    //private DialogInput _dialogInput;

    public EventInputSystem(PlayerUi playerUi, PauseSystem pause, TestMoveItem testMoveItem)//, DialogInput dialogInput)
    {
        _playerUi = playerUi;
        _pause = pause;
        _testMoveItem = testMoveItem;
        //_dialogInput = dialogInput;
    }

    public void InventoryView()
    {
        _playerUi.InventoryView();
    }

    public void Pause()
    {
        _pause.Pause();
    }

    public void ProcessRotate(Vector2 rotate)
    {
        _testMoveItem.ProcessRotate(rotate);
    }

    public void ZoomItem(Vector2 rotate)
    {
        _testMoveItem.Zoom(rotate);
        //_testMoveItem.ProcessRotate(rotate);

    }
}