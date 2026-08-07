using System;
using System.Collections.Generic;

public class DialogueEventParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private DialogueEventData _currentDialogueEventData;
    private PresentData _currentPresentData;

    public DialogueEventParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.DialogueEvent = new List<DialogueEventData>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentDialogueEventData = new DialogueEventData()
                {
                    IdEvent = Convert.ToInt32(token)
                };

                _mainGoogleSettings.DialogueEvent.Add(_currentDialogueEventData);
                break;

            case "Dialogue_Name":
                _currentDialogueEventData.DialogueName = token;
                break;

            case "ID_Cassette":
                _currentDialogueEventData.ID_Cassette = Convert.ToInt32(token);
                break;
            case "Present":
                _currentPresentData = _mainGoogleSettings.Presents.Find((x) => x.NamePresent == token);
                int IdPresent = _currentPresentData == null ? -1 : _currentPresentData.IdPresent;
                _currentDialogueEventData.ID_Present = Convert.ToInt32(IdPresent);
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }
}