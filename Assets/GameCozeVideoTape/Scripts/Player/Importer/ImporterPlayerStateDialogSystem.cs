using System;
using Zenject;

public class ImporterPlayerStateDialogSystem : IDisposable, IInitializable
{
    private DialogSystemCall _dialogSystemCall;
    private PlayerStateControl _playerStateControl;

    public ImporterPlayerStateDialogSystem(DialogSystemCall dialogSystem, PlayerStateControl playerStateControl)
    {
        _dialogSystemCall = dialogSystem;
        _playerStateControl = playerStateControl;
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
        _playerStateControl.ChangeStateControlPlayer(true);
    }
}