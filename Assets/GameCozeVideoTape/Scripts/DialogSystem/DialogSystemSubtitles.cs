using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class DialogSystemSubtitles : IRealizerDialogueble
{
    private DataOpera _dataOpera;
    private OperaSettings _operaSettings;
    private Subtitles _currentSubtitles;

    public DialogSystemSubtitles ( DataOpera dataOpera )
    {
        _dataOpera = dataOpera;
    }

    public bool CheckId(int id)
    {
        bool isSuccess = false;
        _operaSettings = _dataOpera.GetOperaSettingsForIdCassette(id);
        isSuccess = _operaSettings != null;
        Debug.Log($"CheckId, isSuccess: {isSuccess}");
        Debug.Log($"CheckId, _operaSettings, null: {_operaSettings.Subtitles == null}");

        return isSuccess;
    }

    public int GetCountDialogLine()
    {
        return 1;
    }

    public IDialoguebleLine GetDialogLine(int index)
    {
        Debug.Log($"_operaSettings.Subtitles, Null: {_operaSettings.Subtitles == null}");
        _currentSubtitles = _operaSettings.Subtitles;

        return _currentSubtitles.DialogLine;
    }

    public void SetDialogLine()
    {

    }

    public void StartDialog()
    {

    }

    public void EndDialog()
    {

    }
}
