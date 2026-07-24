using System;
using System.Collections.Generic;
using UnityEngine;

public class SubGenreParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private SubGenreSettings _currentSubGenreSettings;
    private GenreSettings _currentGenreSettings;

    public SubGenreParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "Жанр":

                _currentGenreSettings = _mainGoogleSettings.Genre.Find((x) => x.GenreName == token);

                if (_currentGenreSettings == null)
                {
                    Debug.LogError($"Not Found Genre for SubGenre {token}");
                    return;
                }
                _currentSubGenreSettings = new SubGenreSettings();
                _currentGenreSettings.SubGenreList.Add(_currentSubGenreSettings);
                break;

            case "Index":
                _currentSubGenreSettings.IdSubGenre = Convert.ToInt32(token);
                break;
            case "Поджанр":
                _currentSubGenreSettings.SubGenreName = token;
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }
}