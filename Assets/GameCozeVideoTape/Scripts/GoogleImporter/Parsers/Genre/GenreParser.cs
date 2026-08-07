using System;
using System.Collections.Generic;
using UnityEngine;

public class GenreParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private GenreSettings _currentGenreSettings;


    public GenreParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.Genre = new List<GenreSettings>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentGenreSettings = new GenreSettings()
                {
                    IdGenre = Convert.ToInt32(token)
                };
                _currentGenreSettings.SubGenreList = new();
                _mainGoogleSettings.Genre.Add(_currentGenreSettings);
                break;

            case "Genre":
                _currentGenreSettings.GenreName = token;
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }
}