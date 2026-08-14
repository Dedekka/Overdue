using System;

public class AnswerCall : BazeInteracteble
{
    public event Action OnCall;

    private void Awake()
    {
        _isShowPanelUse = true;
    }

    protected override void Interact()
    {
        OnCall?.Invoke();
    }
}