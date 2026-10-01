using System;
using System.Collections.Generic;

public class TutorialEventParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private TutorialEventSettings _currentTutorialEventSettings;

    public TutorialEventParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.TutorialEvent = new List<TutorialEventSettings>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentTutorialEventSettings = new TutorialEventSettings()
                {
                    Id = Convert.ToInt32(token)
                };
                _mainGoogleSettings.TutorialEvent.Add(_currentTutorialEventSettings);
                break;

            case "Description":
                _currentTutorialEventSettings.Description = token;
                break;

            case "Event":
                _currentTutorialEventSettings.TutorialEventType = FindType(token);
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }

    private TutorialEventType FindType(string type)
    {
        TutorialEventType tutorialEventType = type switch
        {
            "OnMove" => TutorialEventType.OnMove,
            "OnPickUp" => TutorialEventType.OnPickUp,
            "OnDrop" => TutorialEventType.OnDrop,
            "OnScroll" => TutorialEventType.OnScroll,
            "OnShow" => TutorialEventType.OnShow,
            "OnTv" => TutorialEventType.OnTv,
            "OnPhone" => TutorialEventType.OnPhone,
            "OnPresent" => TutorialEventType.OnPresent,
            "OnReturned" => TutorialEventType.OnReturned,
            "OnInstall" => TutorialEventType.OnInstall,
            "OnChangeAudio" => TutorialEventType.OnChangeAudio,
            "OnOpera" => TutorialEventType.OnOpera,
            _ => throw new NotImplementedException()
        };
        return tutorialEventType;
    }

   
}
