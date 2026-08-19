using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class DialogSystem
{
    private DialogSystemCall _dialogSystemCall;
    private DialogSystemSubtitles _dialogSystemSubtitles;

    private IRealizerDialogueble _currentRealizer;

    private DialogWaiter _dialogWaiter;
    private float _timeWaitLine;
    // —оздать импортер и в момент когда диалог закачниваетс€ нужно возвращать управление игроку 

    public event Action<bool> OnStateDialog;

    public DialogSystem(DialogSystemSubtitles dialogSystemSubtitles, DialogSystemCall dialogSystemCall, DialogWaiter dialogWaiter, float timeWaitLine)
    {
        _dialogSystemCall = dialogSystemCall;
        _dialogSystemSubtitles = dialogSystemSubtitles;
        _dialogWaiter = dialogWaiter;
        _timeWaitLine = timeWaitLine;
    }

    public bool CheckDialogue(IStarterDialogueble starterDialogue, int id)
    {
        bool isRealizer = false;
        if (starterDialogue is DialogCall)
        {
            _currentRealizer = _dialogSystemCall;
        }
        else if (starterDialogue is DialogSubtitles)
        {
            _currentRealizer = _dialogSystemSubtitles;
        }
        isRealizer = RealizerDialogue(_currentRealizer, id);
        _currentRealizer = isRealizer ? _currentRealizer : null;
        return isRealizer;
    }

    public void StartDialogue()
    {
        if (_currentRealizer == null) { return; }
        ProgressShow(_currentRealizer).Forget();
    }

    private bool RealizerDialogue(IRealizerDialogueble realizer, int id)
    {
        if (realizer == null) { return false; }

        return realizer.CheckId(id);
    }

    private async UniTask ProgressShow(IRealizerDialogueble realizerDialogueble)
    {
        int countDialogLine = PreDialog(realizerDialogueble);
        Debug.Log($"ProgressShow, countDialogLine:{countDialogLine}");
        for (int j = 0; j < countDialogLine; j++)
        {
            IDialoguebleLine dialogLine = realizerDialogueble.GetDialogLine(j);
            if (dialogLine == null) { Debug.LogError("ProgressShow not found IDialoguebleLine"); }

            SetDialogLine(realizerDialogueble, dialogLine);
            await StartDialog(realizerDialogueble, dialogLine);
            await UniTask.Delay(TimeSpan.FromSeconds(_timeWaitLine));
        }
        EndDialog(realizerDialogueble);
    }

    private int PreDialog(IRealizerDialogueble realizer)
    {
        OnStateDialog?.Invoke(true);
        return realizer.GetCountDialogLine();
    }

    private void SetDialogLine(IRealizerDialogueble realizer, IDialoguebleLine dialogLine)
    {
        realizer.SetDialogLine();
        _dialogWaiter.SetDialogLine(dialogLine);
    }

    private async UniTask StartDialog(IRealizerDialogueble realizer, IDialoguebleLine dialogLine)
    {
        realizer.StartDialog();
        await _dialogWaiter.StartShow();
    }

    private void EndDialog(IRealizerDialogueble realizer)
    {
        Debug.Log("EndDialog");
        realizer.EndDialog();
        OnStateDialog?.Invoke(false);
    }
}