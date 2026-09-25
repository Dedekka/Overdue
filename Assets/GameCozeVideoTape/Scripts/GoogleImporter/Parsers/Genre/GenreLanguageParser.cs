using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GenreLanguageParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private GenreLanguage _currentGenreSettings;

    
    public GenreLanguageParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.GenreLanguage = new List<GenreLanguage>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentGenreSettings = new GenreLanguage()
                {
                    IdGenre = Convert.ToInt32(token)
                };
                //_currentGenreSettings.SubGenreList = new();
                _mainGoogleSettings.GenreLanguage.Add(_currentGenreSettings);
                break;

            case "Genre":
                _currentGenreSettings.GenreName = token;
                break;

            case "En_Video":
                _currentGenreSettings.En_Video = Resources.Load<VideoClip>(token); 
                Debug.Log($"PresentsParser, Name:{token}");
                break;
            case "Rus_Video":
                _currentGenreSettings.Rus_Video = Resources.Load<VideoClip>(token);
                Debug.Log($"PresentsParser, Name:{token}");
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }
}