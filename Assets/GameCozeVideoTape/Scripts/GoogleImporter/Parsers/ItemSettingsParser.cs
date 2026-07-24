using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemSettingsParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private ItemSettings _currentitemSettings;
    private GenreSettings _currentGenreSettings;
    private SubGenreSettings _currentSubGenreSettings;

    public ItemSettingsParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.Items = new List<ItemSettings>();
    }

    
    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentitemSettings = new ItemSettings()
                {
                    Id = Convert.ToInt32(token)
                };
                _mainGoogleSettings.Items.Add(_currentitemSettings);
                break;

            case "Original_Title":
                _currentitemSettings.Original_Title = token;
                break;

            case "Genre":
                _currentGenreSettings = _mainGoogleSettings.Genre.Find((x) => x.GenreName == token);
                if (_currentGenreSettings == null)
                {
                    Debug.LogError($"Not Found Genre for Item, {token}");
                    return;
                }

                _currentitemSettings.IdGenre = _currentGenreSettings.IdGenre;
                break;

            case "SubGenre":
                _currentSubGenreSettings = _currentGenreSettings.SubGenreList.Find((x) => x.SubGenreName == token);

                if (_currentGenreSettings == null)
                {
                    Debug.LogError($"Not Found SubGenre for Item, {token}");
                    return;
                }
                _currentitemSettings.IdSubGenre = _currentSubGenreSettings.IdSubGenre;
                break;

            case "Material":
                _currentitemSettings.Material = token;
                break;

            case "MaterialIndex":
                _currentitemSettings.MaterialIndex = Convert.ToInt32(token);
                break;

            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }
}
