using System;
using UnityEngine;

public class DialogEvent
{
    private DialogueEventData _dialogueEventData;
    public event Action<CallData> OnCallData;
    private CallData _callData;

    public DialogEvent()
    {
        _callData = new CallData();
    }

    public void SetDialogSettings(DialogSettings dialogLine)
    {
        _dialogueEventData = dialogLine.DialogueEventData;
    }

    public void StartEvent()
    {
        if (_dialogueEventData.IDPresent > 0)
        {
            Debug.Log($"IdEvent: {_dialogueEventData.IdEvent}, DialogueName: {_dialogueEventData.DialogueName}, ID_Cassette: {_dialogueEventData.IDCassette}, ID_Present: {_dialogueEventData.IDPresent}");
        }
        else
        {
            Debug.Log($"IdEvent: {_dialogueEventData.IdEvent}, DialogueName: {_dialogueEventData.DialogueName}, ID_Cassette: {_dialogueEventData.IDCassette}, ID_Present: No");
        }
        _callData.IdCassetts = _dialogueEventData.IDCassette;
        _callData.IDPresent = _dialogueEventData.IDPresent;
        OnCallData?.Invoke( _callData );
    }
}

public struct CallData
{
    public int IdCassetts;
    public int IDPresent;
}