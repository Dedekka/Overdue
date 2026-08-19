using System;
using UnityEngine;
using Zenject;

public class ImporterImporterDialogSystemCall : IDisposable, IInitializable
{
    private DialogSystemCall _dialogSystemCall;
    private TvManager _tvManager;
    private PauseSystemPlayerStateImporter _pauseSystemPlayerStateImporter;

    public ImporterImporterDialogSystemCall(DialogSystemCall dialogSystem, TvManager tvManager, PauseSystemPlayerStateImporter pauseSystemPlayerStateImporter)
    {
        _dialogSystemCall = dialogSystem;
        _pauseSystemPlayerStateImporter = pauseSystemPlayerStateImporter;
        _tvManager = tvManager;
    }

    public void Initialize()
    {
        _tvManager.OnPlayEpisode += OnStateDialog;
        _dialogSystemCall.OnStateDialog += OnStateDialog;
    }

    public void Dispose()
    {
        _tvManager.OnPlayEpisode -= OnStateDialog;
        _dialogSystemCall.OnStateDialog -= OnStateDialog;
    }

    private void OnStateDialog(bool dialogGoing)
    {
        _pauseSystemPlayerStateImporter.ChangeStateDialog(dialogGoing);
    }
}