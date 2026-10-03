using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

public class DialogSystem
{
    private DialogWaiter _dialogWaiter;

    private DialogSystemCall _dialogSystemCall;
    private DialogSystemSubtitles _dialogSystemSubtitles;
    private DialogSystemPlayerSay _dialogSystemPlayerSay;

    private IRealizerDialogueble _currentRealizer;

    private CancellationTokenSource _cancellationTokenSource;

    private float _timeWaitLine;
    private bool _isPlaying;
    // —оздать импортер и в момент когда диалог закачниваетс€ нужно возвращать управление игроку 

    public event Action<bool> OnStateDialog;

    public DialogSystem(DialogSystemSubtitles dialogSystemSubtitles, DialogSystemCall dialogSystemCall, DialogSystemPlayerSay dialogSystemPlayerSay, DialogWaiter dialogWaiter, float timeWaitLine)
    {
        _dialogSystemPlayerSay = dialogSystemPlayerSay;
        _dialogSystemCall = dialogSystemCall;
        _dialogSystemSubtitles = dialogSystemSubtitles;
        _dialogWaiter = dialogWaiter;
        _timeWaitLine = timeWaitLine;
        _isPlaying = false;
    }

    public bool CheckDialogue(IStarterDialogueble starterDialogue, int id)
    {
        if (_isPlaying) { StopProgressShow(); }   

        bool isRealizer = false;
        if (starterDialogue is DialogCall)
        {
            _currentRealizer = _dialogSystemCall;
        }
        else if (starterDialogue is DialogSubtitles)
        {
            _currentRealizer = _dialogSystemSubtitles;
        }
        else if (starterDialogue is PlayerSaySystem)
        {
            _currentRealizer = _dialogSystemPlayerSay;
        }
        isRealizer = RealizerDialogue(_currentRealizer, id);
        _currentRealizer = isRealizer ? _currentRealizer : null;
        return isRealizer;
    }

    public void StartDialogue()
    {
        if (_currentRealizer == null) { return; }
        _cancellationTokenSource = new CancellationTokenSource();
        ProgressShow(_currentRealizer, _cancellationTokenSource).Forget();
    }

    private bool RealizerDialogue(IRealizerDialogueble realizer, int id)
    {
        if (realizer == null) { return false; }

        return realizer.CheckId(id);
    }

    private async UniTask ProgressShow(IRealizerDialogueble realizerDialogueble, CancellationTokenSource cancellationTokenSource)
    {
        try
        {
            int countDialogLine = PreDialog(realizerDialogueble);
            Debug.Log($"ProgressShow, countDialogLine:{countDialogLine}");
            for (int j = 0; j < countDialogLine; j++)
            {
                IDialoguebleLine dialogLine = realizerDialogueble.GetDialogLine(j);
                if (dialogLine == null) { Debug.LogError("ProgressShow not found IDialoguebleLine"); }

                SetDialogLine(realizerDialogueble, dialogLine);
                await StartDialog(realizerDialogueble, dialogLine, cancellationTokenSource.Token);
                await UniTask.Delay(TimeSpan.FromSeconds(_timeWaitLine), cancellationToken: cancellationTokenSource.Token);
            }
            EndDialog(realizerDialogueble);
        }
        catch (OperationCanceledException)
        {
            // нормальна€ отмена Ч не логируем
        }
        finally
        {
            cancellationTokenSource?.Dispose();
        }
    }

    private void StopProgressShow()
    {
        if (_currentRealizer == null) { return; }

        _cancellationTokenSource?.Cancel();
        _currentRealizer.StopProgressShow();
        // «десь нужно выключать токен ассинхронной операции 
    }

    private int PreDialog(IRealizerDialogueble realizer)
    {
        OnStateDialog?.Invoke(true);
        _isPlaying = true;
        return realizer.GetCountDialogLine();
    }

    private void SetDialogLine(IRealizerDialogueble realizer, IDialoguebleLine dialogLine)
    {
        realizer.SetDialogLine();
        _dialogWaiter.SetDialogLine(dialogLine);
    }

    private async UniTask StartDialog(IRealizerDialogueble realizer, IDialoguebleLine dialogLine, CancellationToken token)
    {
        realizer.StartDialog();
        await _dialogWaiter.StartShow(token);
    }

    private void EndDialog(IRealizerDialogueble realizer)
    {
        _isPlaying = false;
        Debug.Log("EndDialog");
        realizer.EndDialog();
        OnStateDialog?.Invoke(false);
    }
}