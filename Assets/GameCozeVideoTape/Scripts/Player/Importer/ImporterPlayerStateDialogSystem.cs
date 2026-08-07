using System;
using Zenject;

public class ImporterPlayerStateDialogSystem : IDisposable, IInitializable
{
    private DialogSystem _dialogSystem;
    private PlayerStateControl _playerStateControl;

    public ImporterPlayerStateDialogSystem(DialogSystem dialogSystem, PlayerStateControl playerStateControl)
    {
        _dialogSystem = dialogSystem;
        _playerStateControl = playerStateControl;
    }
    public void Initialize()
    {
        _dialogSystem.OnStateDialog += OnStateDialog;
    }

    public void Dispose()
    {
        _dialogSystem.OnStateDialog -= OnStateDialog;
    }

    private void OnStateDialog(bool isPlayerControlON)
    {
        if (isPlayerControlON) { return; }
        _playerStateControl.ChangeStateControlPlayer(true);
    }
}