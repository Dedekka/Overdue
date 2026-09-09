using System;
using System.Collections.Generic;
using UnityEngine;

public class MusicLanguageParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private MusicLanguage _currentitemSettings;

    public MusicLanguageParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.MusicLanguage = new List<MusicLanguage>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentitemSettings = new MusicLanguage()
                {
                    Id = Convert.ToInt32(token)
                };
                _mainGoogleSettings.MusicLanguage.Add(_currentitemSettings);
                break;

            case "En":
                _currentitemSettings.En = token;
                break;

            case "Rus":
                _currentitemSettings.Ru = token;
                break;
            //case "Ja":
            //    _currentitemSettings.JPN = token;
            //    break;

            default:
                throw new Exception($"Invalid header: {headerName}, Cell: {token}");
        }
    }

}
