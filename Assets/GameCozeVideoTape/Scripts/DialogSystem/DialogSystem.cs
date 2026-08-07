using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class DialogSystem
{
    private DataDialogue _dataDialogue;
    private DialogSettings _dialogSettings;
    private DialogWaiter _dialogWaiter;
    private DialogSound _dialogSound;
    private DialogEvent _dialogEvent;
    private float _timeWaitLine;

    // —оздать импортер и в момент когда диалог закачниваетс€ нужно возвращать управление игроку 

    public event Action<bool> OnStateDialog;

    public DialogSystem(DataDialogue dataDialogue, DialogWaiter dialogWaiter, float timeWaitLine, DialogSound dialogSound, DialogEvent dialogEvent)
    {
        _dataDialogue = dataDialogue;
        _dialogWaiter = dialogWaiter;
        _timeWaitLine = timeWaitLine;
        _dialogSound = dialogSound;
        _dialogEvent = dialogEvent;
    }
    
    public void StartDialogue(int id)
    {
        ShowTest(_dataDialogue.GetDialog(id));
    }

    private void ShowTest(DialogSettings dialogSettings)
    {
        // ћы определ€ем что диалог существует
        // ћы передаем по стройчно что диалог воспроизводитс€ по репликам
        // ћы отдаем строку в DialogWaiter дл€ по символьного отображени€
        // ћы получаем результат отображени€ из DialogWaiter
        // передаем его в ViewDialog
        // мы передаем команду на звук
        // ћы отслеживаем событие завершени€ строк

        // когда DialogLines.Count завершен вызываем событие срабатывани€ конца диалога


        if (dialogSettings == null) { Debug.LogError("DialogSystem Not Found DialogSettings"); return; }

        _dialogSettings = dialogSettings;
        Debug.Log($"Id: {_dialogSettings.Id}, dialogSettings: {_dialogSettings.DialogLines.Count}");
        ProgressShow().Forget();
    }

    private async UniTask ProgressShow()
    {
        OnStateDialog?.Invoke(true);
        for (int j = 0; j < _dialogSettings.DialogLines.Count; j++)
        {
            DialogLine dialogLine = _dialogSettings.DialogLines[j];
            _dialogSound.SetFmodSound(dialogLine);
            _dialogWaiter.SetDialogLine(dialogLine);
            _dialogEvent.SetDialogSettings(_dialogSettings);
            _dialogSound.StartSound();
            await _dialogWaiter.StartShow();
            await UniTask.Delay(TimeSpan.FromSeconds(_timeWaitLine));
            Debug.Log($"Id: {dialogLine.IdNumber}, Character: {dialogLine.Character}, dialogLine: {dialogLine.Line}");
        }
        _dialogEvent.StartEvent();
        _dialogSound.StopSound();
        OnStateDialog?.Invoke(false);
    }
}

