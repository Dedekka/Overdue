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

                int IdEventHistory = Convert.ToInt32(token);

                _currentDialogueEventData = new HistoryEventSettings()
                {
                    IdEventHistory = IdEventHistory
                };
                _mainGoogleSettings.HistoryEvent.Add(_currentDialogueEventData);
                break;

            case "Name":
                _currentDialogueEventData.NameEvent = token;
                break;

            case "Count Cassette":

                if (int.TryParse(token, out int CountCassette))
                {
                    _currentDialogueEventData.CountCassette = CountCassette;
                }
                else
                {
                    _currentDialogueEventData.CountCassette = -1;
                }
                break;

            case "Description":
                break;

            case "ID_Dialogue":

                if (int.TryParse(token, out int id_Dialogue))
                {
                    _currentDialogueEventData.IDDialogue = id_Dialogue;
                }
                else
                {
                    _currentDialogueEventData.IDDialogue = -1;
                }
               
                break;

            case "ID_Cassette":

                if (int.TryParse(token, out int id_Cassette))
                {
                    _currentDialogueEventData.IDCassette = id_Cassette;
                }
                else
                {
                    _currentDialogueEventData.IDCassette = -1;
                }

                break;

            case "ID_Present":
                if (int.TryParse(token, out int id_Present))
                {
                    _currentDialogueEventData.IDPresent = id_Present;
                }
                else
                {
                    _currentDialogueEventData.IDPresent = -1;
                }
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }
}