using System;

public class RecorderController : BazeInteracteble
{
    public event Action OnChangeState;

    private void Awake()
    {
        _isShowPanelUse = true;
    }

    protected override void Interact()
    {
        OnChangeState?.Invoke();
    }
}