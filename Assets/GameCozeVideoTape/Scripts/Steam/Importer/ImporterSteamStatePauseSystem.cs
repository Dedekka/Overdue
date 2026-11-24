using System;
using Zenject;

public class ImporterSteamStatePauseSystem : IDisposable, IInitializable
{
    private PauseSystem _pauseSystem;
    private ControlSteamState _controlSteamState;
    private RundomChangerSteamState _rundomChangerSteamState;

    public ImporterSteamStatePauseSystem(PauseSystem pauseSystem, ControlSteamState controlSteamState, RundomChangerSteamState rundomChangerSteamState)
    {
        _pauseSystem = pauseSystem;
        _controlSteamState = controlSteamState;
        _rundomChangerSteamState = rundomChangerSteamState;
    }

    public void Initialize()
    {
        _pauseSystem.OnChangeStatePause += OnChangeStatePause;
    }

    public void Dispose()
    {
        _pauseSystem.OnChangeStatePause -= OnChangeStatePause;
    }

    private void OnChangeStatePause(bool isPause)
    {
        if (isPause)
        {
            _controlSteamState.SetPlayerState(DataSteamStateKey.GamePause);
        }
        else
        {
            _rundomChangerSteamState.ChangeState();
        }
    }
}