using System;
using UnityEngine;
using Zenject;

public class ImporterImporterDialogSystemCall : IDisposable, IInitializable
{
    private DialogSystemCall _dialogSystemCall;
    private TvManager _tvManager;
    private CutSceneController _cutSceneController;
    private PauseSystemPlayerStateImporter _pauseSystemPlayerStateImporter;

    public ImporterImporterDialogSystemCall(DialogSystemCall dialogSystem, TvManager tvManager, PauseSystemPlayerStateImporter pauseSystemPlayerStateImporter, CutSceneController cutSceneController)
    {
        _dialogSystemCall = dialogSystem;
        _pauseSystemPlayerStateImporter = pauseSystemPlayerStateImporter;
        _cutSceneController = cutSceneController;
        _tvManager = tvManager;
    }

    public void Initialize()
    {
        _tvManager.OnPlayEpisode += OnStateDialog;
        _dialogSystemCall.OnStateDialog += OnStateDialog;
        _cutSceneController.OnCutscene += OnStateDialog;
    }

    public void Dispose()
    {
        _tvManager.OnPlayEpisode -= OnStateDialog;
        _dialogSystemCall.OnStateDialog -= OnStateDialog;
        _cutSceneController.OnCutscene -= OnStateDialog;
    }

    private void OnStateDialog(bool dialogGoing)
    {
        _pauseSystemPlayerStateImporter.ChangeStateDialog(dialogGoing);
    }
}