using System;
using System.Collections.Generic;
using UnityEngine;

public class PresentLanguageParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private PresentLanguageSettings _currentGenreSettings;

    public PresentLanguageParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.PresentLanguage = new List<PresentLanguageSettings>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentGenreSettings = new PresentLanguageSettings()
                {
                    IdPresent = Convert.ToInt32(token)
                };
                _mainGoogleSettings.PresentLanguage.Add(_currentGenreSettings);
                break;

            case "En":
                _currentGenreSettings.En_NamePresent = token;
                Debug.Log($"PresentsParser, Name:{token}");
                break;

            case "Rus":
                _currentGenreSettings.Rus_NamePresent = token;
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }
}