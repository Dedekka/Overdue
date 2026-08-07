using System;
using Zenject;

public class PauseSystemPlayerStateImporter : IDisposable, IInitializable
{
    private PauseSystem _pauseSystem;
    private PlayerStateControl _playerStateControl;
    private bool _isDialogGoing;

 
    public PauseSystemPlayerStateImporter(PauseSystem pauseSystem, PlayerStateControl playerStateControl)
    {
        _pauseSystem = pauseSystem;
        _playerStateControl = playerStateControl;
    }
    public void Initialize()
    {
        _pauseSystem.OnChangeStatePause += OnChangeStatePause;
    }

    public void Dispose()
    {
        _pauseSystem.OnChangeStatePause -= OnChangeStatePause;
    }

    public void ChangeStateDialog(bool isDialogGoing)
    {
        _isDialogGoing = isDialogGoing;
    }

    private void OnChangeStatePause(bool isPlayerControlON)
    {
        if (_isDialogGoing) { return; }
        _playerStateControl.ChangeStateControlPlayer(!isPlayerControlON);
    }
}