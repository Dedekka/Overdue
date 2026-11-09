using System;
using System.Collections.Generic;
using UnityEngine;

public class GamePadKeyboardLanguageParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private GamePadKeyboardLanguageSettings _currentGamePadKeyboardLanguageSettings;
    
    public GamePadKeyboardLanguageParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.GamePadKeyboardLanguageSettings = new List<GamePadKeyboardLanguageSettings>();
    }
    
    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "Id":
                _currentGamePadKeyboardLanguageSettings = new GamePadKeyboardLanguageSettings()
                {
                    ID = Convert.ToInt32(token)
                };
                //_currentGenreSettings.SubGenreList = new();
                _mainGoogleSettings.GamePadKeyboardLanguageSettings.Add(_currentGamePadKeyboardLanguageSettings);
                break;

            case "KEY":
                _currentGamePadKeyboardLanguageSettings.KEY = token;
                //_currentGenreSettings.SubGenreList = new();
                break;

            case "En":
                _currentGamePadKeyboardLanguageSettings.En = token;
                break;

            case "En_Secondary":
                _currentGamePadKeyboardLanguageSettings.En_Secondary = token;
                break;

            case "Rus":
                _currentGamePadKeyboardLanguageSettings.Rus = token;
                break;
            case "Rus_Secondary":
                _currentGamePadKeyboardLanguageSettings.Rus_Secondary = token;
                break;
          
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }
}