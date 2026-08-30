using UnityEngine;

public class LookItemControlUi 
{
    private PlayerUi _playerCanvas;
    private LookItemUi _lookItemCanvas;

    public LookItemControlUi(LookItemUi lookItemCanvas, PlayerUi playerCanvas)
    {
        _lookItemCanvas = lookItemCanvas;
        _playerCanvas = playerCanvas;
    }

    public void ActiveUi(bool isActive)
    {
        _playerCanvas.ChangeOtherGoup(!isActive);
        _lookItemCanvas.gameObject.SetActive(isActive);
    }

    public void SetText(string text)
    {
        _lookItemCanvas.SetText(text);
    }
}