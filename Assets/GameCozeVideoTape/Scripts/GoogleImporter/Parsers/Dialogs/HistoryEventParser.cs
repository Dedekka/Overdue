using System;
using System.Collections.Generic;

public class HistoryEventParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private HistoryEventSettings _currentDialogueEventData;

    public HistoryEventParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.HistoryEvent = new List<HistoryEventSettings>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentDialogueEventData = new HistoryEventSettings()
                {
                    IdEventHistory = Convert.ToInt32(token)
                };
                _mainGoogleSettings.HistoryEvent.Add(_currentDialogueEventData);
                break;

            case "Name":
                _currentDialogueEventData.NameEvent = token;
                break;

            case "Count Cassette":
                _currentDialogueEventData.CountCassette = Convert.ToInt32(token);
                break;

            case "Description":
                break;

            case "ID_Dialogue":

                if (int.TryParse(token, out int id_Dialogue))
                {
                    _currentDialogueEventData.IDDialogue = id_Dialogue;
                }

                break;

            case "ID_Cassette":

                if (int.TryParse(token, out int id_Cassette))
                {
                    _currentDialogueEventData.IDCassette = id_Cassette;
                }

                break;

            case "ID_Present":
                if (int.TryParse(token, out int id_Present))
                {
                    _currentDialogueEventData.IDPresent = id_Present;
                }
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }
}