using System;
using UnityEngine;
using Zenject;

public class ImporterPauseSystemControlVisibleCursor : IDisposable, IInitializable
{
    private ControlVisibleCursor _controlVisibleCursor;
    private PauseSystem _pauseSystem;
    private bool _isPause;

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
        _isPause = isPause;
        _controlVisibleCursor.SetVisibleState(_isPause);
        _controlVisibleCursor.CheckVisibleCursor();
    }
}