using System;

public class DialogSystemCall : IRealizerDialogueble
{
    private DataDialogue _dataDialogue;
    private DialogSettings _dialogSettings;
    private DialogSound _dialogSound;
    private DialogEvent _dialogEvent;
    private DialogLine _currentDialogLine;

    public event Action<bool> OnStateDialog;

    public DialogSystemCall(DataDialogue dataDialogue, DialogSound dialogSound, DialogEvent dialogEvent)
    {
        _dialogSound = dialogSound;
        _dialogEvent = dialogEvent;
        _dataDialogue = dataDialogue;
    }

    public bool CheckId(int id)
    {
        bool isSuccess = false;
        _dialogSettings = _dataDialogue.GetDialog(id);
        isSuccess = _dialogSettings != null;
        return isSuccess;
    }

    public int GetCountDialogLine()
    {
        OnStateDialog?.Invoke(true);
        return _dialogSettings.DialogLines.Count;
    }

    public IDialoguebleLine GetDialogLine(int index)
    {
        _currentDialogLine = _dialogSettings.DialogLines[index];

        return _currentDialogLine;
    }

    public void SetDialogLine()
    {
        _dialogSound.SetFmodSound(_currentDialogLine.SoundLine);
        _dialogEvent.SetDialogSettings(_dialogSettings);
    }

    public void StartDialog()
    {
        _dialogSound.StartSound();
    }

    public void EndDialog()
    {
        _dialogEvent.StartEvent();
        _dialogSound.StopSound();
        OnStateDialog?.Invoke(false);
    }
}