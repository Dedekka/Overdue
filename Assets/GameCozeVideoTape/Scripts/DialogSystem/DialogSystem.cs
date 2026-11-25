using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

public class DialogSystem : IDisposable
{
    private DialogWaiter _dialogWaiter;

    private DialogSystemCall _dialogSystemCall;
    private DialogSystemPlayerSay _dialogSystemPlayerSay;

    private IRealizerDialogueble _currentRealizer;
    private UniTask _currentDialogTask;
    private CancellationTokenSource _sourceWaitLine;
    private CancellationTokenSource _sourceMainDialoge;

    private float _timeWaitLine;
    private bool _isPlaying;
    // —оздать импортер и в момент когда диалог закачниваетс€ нужно возвращать управление игроку 

    public event Action<bool> OnStateDialog;

    public DialogSystem(DialogSystemCall dialogSystemCall, DialogSystemPlayerSay dialogSystemPlayerSay, DialogWaiter dialogWaiter, float timeWaitLine)
    {
        _dialogSystemPlayerSay = dialogSystemPlayerSay;
        _dialogSystemCall = dialogSystemCall;
        _dialogWaiter = dialogWaiter;
        _timeWaitLine = timeWaitLine;
        _isPlaying = false;
    }

    public async UniTask<bool> CheckDialogue(IStarterDialogueble starterDialogue, int id)
    {
        if (_isPlaying) 
        { 
           await StopProgressShow();
        }
        bool isRealizer = false;
        if (starterDialogue is DialogCall)
        {
            _currentRealizer = _dialogSystemCall;
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
        _sourceMainDialoge = new CancellationTokenSource();
        _currentDialogTask = ProgressShow(_currentRealizer, _sourceMainDialoge.Token);
    }

    public void StopDialogue()
    {
        _sourceWaitLine?.Cancel();
    }

    private bool RealizerDialogue(IRealizerDialogueble realizer, int id)
    {
        if (realizer == null) { return false; }

        return realizer.CheckId(id);
    }

    private async UniTask ProgressShow(IRealizerDialogueble realizerDialogueble, CancellationToken token)
    {
        int countDialogLine = PreDialog(realizerDialogueble);
        Debug.Log($"ProgressShow, countDialogLine:{countDialogLine}");
        try
        {
            for (int j = 0; j < countDialogLine; j++)
            {
                IDialoguebleLine dialogLine = realizerDialogueble.GetDialogLine(j);
                if (dialogLine == null) { Debug.LogError("ProgressShow not found IDialoguebleLine"); }

                SetDialogLine(realizerDialogueble, dialogLine);
                ControlEndToken(_sourceWaitLine);
                _sourceWaitLine = new CancellationTokenSource();

                if (token.IsCancellationRequested) { break; }

                await UniTask.WhenAll(
                 StartDialog(realizerDialogueble, dialogLine),
                 UniTask.Delay(TimeSpan.FromSeconds(_timeWaitLine), cancellationToken: _sourceWaitLine.Token).SuppressCancellationThrow()
                 );
            }
        }
        catch (OperationCanceledException)
        {
            // нормальна€ отмена Ч не логируем
        }
        finally
        {
            EndDialog(realizerDialogueble);
        }
    }

    private async UniTask StopProgressShow()
    {
        if (_currentRealizer == null) { return; }

        ControlEndToken(_sourceWaitLine);
        ControlEndToken(_sourceMainDialoge);
        _currentRealizer.StopProgressShow();
        _dialogWaiter.EndPrintChar();
        _isPlaying = false;
        await _currentDialogTask;
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

    private async UniTask StartDialog(IRealizerDialogueble realizer, IDialoguebleLine dialogLine)
    {
        realizer.StartDialog();
        await _dialogWaiter.StartShow();
    }

    private void EndDialog(IRealizerDialogueble realizer)
    {
        _isPlaying = false;
        Debug.Log("EndDialog");
        realizer.EndDialog();
        OnStateDialog?.Invoke(false);
    }

    private void ControlEndToken(CancellationTokenSource cancellationToken)
    {
        cancellationToken?.Cancel();
    }

    public void Dispose()
    {
        ControlEndToken(_sourceMainDialoge);
        ControlEndToken(_sourceWaitLine);
        _sourceMainDialoge?.Dispose();
        _sourceWaitLine?.Dispose();
    }
}