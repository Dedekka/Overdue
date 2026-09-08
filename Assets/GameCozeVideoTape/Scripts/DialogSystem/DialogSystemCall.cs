using DG.Tweening;
using System;

public class DialogSystemCall : IRealizerDialogueble
{
    private DataDialogue _dataDialogue;
    private DialogSettings _dialogSettings;
    private ControlDialogLanguage _controlDialogLanguage;
    private DialogSound _dialogSound;
    private DialogEvent _dialogEvent;
    private DialogLine _currentDialogLine;
    private SoundLine _soundLine;

    public event Action<bool> OnStateDialog;

    public DialogSystemCall(DataDialogue dataDialogue, DialogSound dialogSound, DialogEvent dialogEvent, ControlDialogLanguage controlDialogLanguage)
    {
        _dialogSound = dialogSound;
        _dialogEvent = dialogEvent;
        _dataDialogue = dataDialogue;
        _controlDialogLanguage = controlDialogLanguage;
    }

    public bool CheckId(int id)
    {
        bool isSuccess = false;
        _dialogSettings = _dataDialogue.GetDialog(id);
        _controlDialogLanguage.GetLanguage(id);
        isSuccess = _dialogSettings != null;
        return isSuccess;
    }

    public int GetCountDialogLine()
    {
        OnStateDialog?.Invoke(true);
        return _controlDialogLanguage.GetCountDialogLine();
    }

    public IDialoguebleLine GetDialogLine(int index)
    {
        _currentDialogLine = _controlDialogLanguage.GetDialogLine(index);
        _soundLine = _dialogSettings.SoundLine[index];
        return _currentDialogLine;
    }

    public void SetDialogLine()
    {
        _dialogSound.SetFmodSound(_soundLine.PathFmod);
        //_dialogEvent.SetDialogSettings(_dialogSettings);
    }

    public void StartDialog()
    {
        _dialogSound.StartSound();
    }

    public void EndDialog()
    {
        //_dialogEvent.StartEvent();
        _dialogSound.StopSound();
        OnStateDialog?.Invoke(false);
    }
}