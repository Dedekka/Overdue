using System;
using UnityEngine;
using Zenject;

public class ImporterDialogSystemCallPhoneAnimation : IDisposable, IInitializable
{
    private DialogSystemCall _dialogSystemCall;
    private PhoneAnimation _phoneAnimation;

    public ImporterDialogSystemCallPhoneAnimation(DialogSystemCall dialogSystem, PhoneAnimation phoneAnimation)
    {
        _dialogSystemCall = dialogSystem;
        _phoneAnimation = phoneAnimation;
    }
    public void Initialize()
    {
        _dialogSystemCall.OnStateDialog += OnStateDialog;
    }

    public void Dispose()
    {
        _dialogSystemCall.OnStateDialog -= OnStateDialog;
    }

    private void OnStateDialog(bool isPlayerControlON)
    {
        if (isPlayerControlON) { return; }
        _phoneAnimation.DeactivationCallAnimation();
    }
}
