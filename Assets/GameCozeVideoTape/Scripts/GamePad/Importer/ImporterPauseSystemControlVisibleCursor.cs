using System;
using UnityEngine;
using Zenject;

public class ImporterPauseSystemControlVisibleCursor : IDisposable, IInitializable
{
    private ControlVisibleCursor _controlVisibleCursor;
    private PauseSystem _pauseSystem;

    public ImporterPauseSystemControlVisibleCursor(ControlVisibleCursor controlVisibleCursor, PauseSystem pauseSystem)
    {
        _controlVisibleCursor = controlVisibleCursor;
        _pauseSystem = pauseSystem;
    }

    public void Dispose()
    {
        _pauseSystem.OnChangeStatePause -= OnChangeStatePause;
    }

    public void Initialize()
    {
        _pauseSystem.OnChangeStatePause += OnChangeStatePause;
    }

    private void OnChangeStatePause(bool isPause)
    {
        _controlVisibleCursor.SetVisibleState(isPause);
        _controlVisibleCursor.CheckVisibleCursor();
    }
}