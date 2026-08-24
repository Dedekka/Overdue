using System;
using System.Collections.Generic;
using UnityEngine;

public class PresentsParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private PresentSettings _currentGenreSettings;

    public PresentsParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.Presents = new List<PresentSettings>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentGenreSettings = new PresentSettings()
                {
                    IdPresent = Convert.ToInt32(token)
                };

                _mainGoogleSettings.Presents.Add(_currentGenreSettings);
                break;

            case "Name":
                _currentGenreSettings.NamePresent = token;
                Debug.Log($"PresentsParser, Name:{token}");
                break;

            case "MaterialIndex":
                _currentGenreSettings.MaterialIndex = Convert.ToInt32(token);

                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }
}
