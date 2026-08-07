using System;
using UnityEngine;
using Zenject;

public class ImporterDialogSystemViewDialog : IDisposable, IInitializable
{
    private DialogSystem _dialogSystem;
    private ViewDialog _viewDialog;

    public ImporterDialogSystemViewDialog(DialogSystem dialogSystem, ViewDialog viewDialog)
    {
        _dialogSystem = dialogSystem;
        _viewDialog = viewDialog;
    }

    public void Dispose()
    {
        _dialogSystem.OnStateDialog -= OnStateDialog;
    }

    public void Initialize()
    {
        _dialogSystem.OnStateDialog += OnStateDialog;
    }

    private void OnStateDialog(bool isVisible)
    {
        _viewDialog.ControlVisible(isVisible);
    }
}