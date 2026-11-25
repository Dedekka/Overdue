using Zenject;

public class ControlSkipCall
{
    private DialogWaiter _dialogWaiter;
    private DialogSystem _dialogSystem;

    [Inject]
    public void Construct(DialogWaiter dialogWaiter, DialogSystem dialogSystem)
    {
        _dialogWaiter = dialogWaiter;
        _dialogSystem = dialogSystem;
    }

    public void ActiveSkip()
    {
        Skip();
    }

    private void Skip()
    {
        if (_dialogWaiter.CheckPrintChar())
        {
            _dialogWaiter.EndPrintChar();
        }
        else
        {
            _dialogSystem.StopDialogue();
        }
    }
}