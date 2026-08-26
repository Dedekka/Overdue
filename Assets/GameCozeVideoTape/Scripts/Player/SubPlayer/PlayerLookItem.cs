using System;

public class PlayerLookItem
{
    public LookItemRotate LookItemRotate => _lookItemRotate;
    public LookItemCamera LookItemCamera => _lookItemCamera;

    public bool IsActive => _isActive;
    private LookItemMove _lookItemMove;
    private LookItemRotate _lookItemRotate;
    private LookItemCamera _lookItemCamera;
    private LookItemEffects _lookItemEffects;
    private LookItemControlUi _lookItemUi;
    private AudioItemDrop _currentItem;
    private bool _isActive;

    public event Action<bool> OnStateLookItem;

    public PlayerLookItem(LookItemMove lookItemMove, LookItemRotate lookItemRotate, LookItemCamera lookItemCamera, LookItemControlUi lookItemUi, LookItemEffects lookItemEffects)
    {
        _lookItemMove = lookItemMove;
        _lookItemRotate = lookItemRotate;
        _lookItemCamera = lookItemCamera;
        _lookItemUi = lookItemUi;
        _lookItemEffects = lookItemEffects;
        _isActive = false;
    }

    public void SetItem(AudioItemDrop currentItem)
    {
        _currentItem = currentItem;
    }

    public void Move()
    {
        if (_currentItem == null) { return; }
        Active();
    }

    public void EndLookItem()
    {
        _isActive = false;
        ChangeState();
        End();
    }

    private void Active()
    {
        _isActive = true;
        _lookItemMove.Move(_currentItem);
        _lookItemUi.SetText(_currentItem.MusicCassetteSettings.MusicName);
        ChangeState();
    }

    private void ChangeState()
    {
        _lookItemRotate.ActiveRotate(_isActive);
        _lookItemCamera.ActiveZoom(_isActive);
        _lookItemUi.ActiveUi(_isActive);
        _lookItemEffects.ActiveEffects(_isActive);
        OnStateLookItem?.Invoke(_isActive);
    }

    private void End()
    {
        _currentItem.ActiveAudioSlot();
        _currentItem = null;
    }
}