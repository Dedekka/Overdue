using System;
using System.Collections.Generic;

public class ItemSettingsParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private ItemSettings _currentitemSettings;

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
                _currentitemSettings.Genre = token;
                break;

            case "SubGenre":
                _currentitemSettings.SubGenre = token;
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
