using System;
using UnityEngine;
using Zenject;

public class DialogSubtitles : IStarterDialogueble, IDisposable, IInitializable
{
    private DialogSystem _dialogSystem;
    private SubtitlesWaiter _subtitlesWaiter;
    //private int _dialogIndex;

    [Inject]
    public void Construct(DialogSystem dialogSystem, SubtitlesWaiter subtitlesWaiter)
    {
        _dialogSystem = dialogSystem;
        _subtitlesWaiter = subtitlesWaiter;
    }

    public void Initialize()
    {
        _subtitlesWaiter.OnEndWait += ShowSubtitles;
    }

    public void Dispose()
    {
        _subtitlesWaiter.OnEndWait -= ShowSubtitles;
    }

    public bool StartWaitSubtitles(OperaSettings _currentEpisode)
    {
        //bool SuccessStart = CheckCurrentDialogs(_currentEpisode.Id);
        //SuccessStart = SuccessStart ? _dialogSystem.CheckDialogue(this, _currentEpisode.Id) : false;
        bool SuccessStart = _dialogSystem.CheckDialogue(this, _currentEpisode.Id_Cassette);
        Debug.Log($"StartWaitSubtitles, SuccessStart:{SuccessStart}");
        if (SuccessStart)
        {
            _subtitlesWaiter.StartWait(_currentEpisode.Subtitles);
        }
        else
        {
            Debug.LogError("Dialog End ");
        }
        return SuccessStart;
    }

    private void ShowSubtitles()
    {
        Debug.Log($"ShowSubtitles, StartDialogue");
        _dialogSystem.StartDialogue();
    }

    //private bool CheckCurrentDialogs(int dialogIndex)
    //{
    //    bool isNewDialog = false;

    //    if (dialogIndex < 0 || dialogIndex == _dialogIndex)
    //    {
    //        return isNewDialog;
    //    }
    //    _dialogIndex = dialogIndex;
    //    isNewDialog = true;
    //    return isNewDialog;
    //}
}