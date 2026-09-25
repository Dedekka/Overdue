using System;
using System.Collections.Generic;

public class TutorialEventLanguageParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private TutorialEventSettings _currentTutorialEventSettings;

    

    public TutorialEventLanguageParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.TutorialEventLanguage = new List<TutorialEventSettings>();
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
                //_currentGenreSettings.SubGenreList = new();
                _mainGoogleSettings.TutorialEventLanguage.Add(_currentTutorialEventSettings);
                break;

            case "Zh":
                _currentTutorialEventSettings.ZHCN = token;
                break;

            case "En":
                _currentTutorialEventSettings.En = token;
                break;

            case "De":
                _currentTutorialEventSettings.DE = token;
                break;
            case "Es":
                _currentTutorialEventSettings.ES = token;
                break;
            case "Rus":
                _currentTutorialEventSettings.Ru = token;
                break;
            case "Ja":
                _currentTutorialEventSettings.JPN = token;
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }
}