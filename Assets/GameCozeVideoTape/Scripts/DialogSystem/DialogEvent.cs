using UnityEngine;

public class DialogEvent
{
    private DialogueEventData _dialogueEventData;

    public void SetDialogSettings(DialogSettings dialogLine)
    {
        _dialogueEventData = dialogLine.DialogueEventData;
    }

    public void StartEvent()
    {
        if (_dialogueEventData.ID_Present > 0)
        {
            Debug.Log($"IdEvent: {_dialogueEventData.IdEvent}, DialogueName: {_dialogueEventData.DialogueName}, ID_Cassette: {_dialogueEventData.ID_Cassette}, ID_Present: {_dialogueEventData.ID_Present}");
        }
        else
        {
            Debug.Log($"IdEvent: {_dialogueEventData.IdEvent}, DialogueName: {_dialogueEventData.DialogueName}, ID_Cassette: {_dialogueEventData.ID_Cassette}, ID_Present: No");
        }

    }
}

public struct CallData
{
    public int IdCassetts;
    public int IdItem;
}