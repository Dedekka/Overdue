using System;
using Zenject;

public class ImporterPlayerStatePlayerInput : IDisposable, IInitializable
{
    private PlayerStateControl _playerStateControl;
    private PlayerInputControl _playerInputControl;

    public ImporterPlayerStatePlayerInput(PlayerStateControl playerStateControl, PlayerInputControl playerInputControl)
    {
        _playerStateControl = playerStateControl;
        _playerInputControl = playerInputControl;
    }

    public void Initialize()
    {
        _playerStateControl.OnChangeStateControlPlayer += OnChangeStateControlPlayer;
    }

    public void Dispose()
    {
        _playerStateControl.OnChangeStateControlPlayer -= OnChangeStateControlPlayer;
    }

    private void OnChangeStateControlPlayer(bool isPlayerControlON)
    {
        _playerInputControl.ChangePlayerControl(isPlayerControlON);
    }
}
