using System;
using UnityEngine;
using Zenject;

public class ImporterImporterDialogSystem : IDisposable, IInitializable
{
    private DialogSystem _dialogSystem;
    private PauseSystemPlayerStateImporter _pauseSystemPlayerStateImporter;

    public ImporterImporterDialogSystem(DialogSystem dialogSystem, PauseSystemPlayerStateImporter pauseSystemPlayerStateImporter)
    {
        _dialogSystem = dialogSystem;
        _pauseSystemPlayerStateImporter = pauseSystemPlayerStateImporter;
    }

    public void Initialize()
    {
        _dialogSystem.OnStateDialog += OnStateDialog;
    }

    public void Dispose()
    {
        _dialogSystem.OnStateDialog -= OnStateDialog;
    }

    private void OnStateDialog(bool dialogGoing)
    {
        _pauseSystemPlayerStateImporter.ChangeStateDialog(dialogGoing);
    }
}