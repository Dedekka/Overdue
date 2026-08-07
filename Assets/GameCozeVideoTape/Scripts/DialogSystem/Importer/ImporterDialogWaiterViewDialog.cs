using System;
using UnityEngine;
using Zenject;

public class ImporterDialogWaiterViewDialog : IDisposable, IInitializable
{
    private DialogWaiter _dialogWaiter;
    private ViewDialog _viewDialog;

    public ImporterDialogWaiterViewDialog(DialogWaiter dialogWaiter, ViewDialog viewDialog)
    {
        _dialogWaiter = dialogWaiter;
        _viewDialog = viewDialog;
    }

    public void Dispose()
    {
        _dialogWaiter.OnUpdateDialogText -= OnUpdateDialogText;
    }

    public void Initialize()
    {
        _dialogWaiter.OnUpdateDialogText += OnUpdateDialogText;
    }

    private void OnUpdateDialogText(UpdateDialogText updateDialogText)
    {
        _viewDialog.SetName(updateDialogText.CharacterName);
        _viewDialog.SetDialog(updateDialogText.Text);
    }
}
