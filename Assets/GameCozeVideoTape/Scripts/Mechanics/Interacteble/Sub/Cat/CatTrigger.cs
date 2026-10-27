using System;

public class CatTrigger : BazeInteracteble
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

