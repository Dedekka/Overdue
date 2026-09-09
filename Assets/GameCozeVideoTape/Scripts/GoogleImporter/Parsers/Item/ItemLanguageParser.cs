using System;
using System.Collections.Generic;

public class ItemLanguageParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private ItemLanguage _currentitemSettings;

    public ItemLanguageParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.Language = new List<ItemLanguage>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentitemSettings = new ItemLanguage()
                {
                    Id = Convert.ToInt32(token)
                };
                _mainGoogleSettings.Language.Add(_currentitemSettings);
                break;

            case "Original_Title":
                _currentitemSettings.Original_Title = token;
                break;

            case "Zh":
                _currentitemSettings.ZHCN = token;
                break;

            case "En":
                _currentitemSettings.En = token;
                break;

            case "De":
                _currentitemSettings.DE = token;
                break;
            case "Es":
                _currentitemSettings.ES = token;
                break;
            case "Rus":
                _currentitemSettings.Ru = token;
                break;
            case "Ja":
                _currentitemSettings.JPN = token;
                break;

            default:
                throw new Exception($"Invalid header: {headerName}, Cell: {token}");
        }
    }
}
