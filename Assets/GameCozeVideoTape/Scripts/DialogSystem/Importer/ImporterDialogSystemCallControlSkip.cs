using System;
using Zenject;

public class ImporterDialogSystemCallControlSkip : IDisposable, IInitializable
{
    private InputActionCallSkip _inputActionCallSkip;
    private DialogSystemCall _dialogSystemCall;
    private bool _isSubSkip;

    public ImporterDialogSystemCallControlSkip(InputActionCallSkip inputActionCallSkip, DialogSystemCall dialogSystemCall)
    {
        _inputActionCallSkip = inputActionCallSkip;
        _dialogSystemCall = dialogSystemCall;
        _isSubSkip = false;
    }

    public void Initialize()
    {
        _dialogSystemCall.OnStateDialog += OnStateDialog;
    }

    public void Dispose()
    {
        _dialogSystemCall.OnStateDialog -= OnStateDialog;
    }

    private void OnStateDialog(bool isSubSkip)
    {
        if (_isSubSkip == isSubSkip) { return; }

        _isSubSkip = isSubSkip;
        _inputActionCallSkip.SubCallSkip(_isSubSkip);
    }
}