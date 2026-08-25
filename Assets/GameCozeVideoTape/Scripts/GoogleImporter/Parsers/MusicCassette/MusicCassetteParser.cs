using System;
using System.Collections.Generic;

public class MusicCassetteParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private MusicCassetteSettings _currentGenreSettings;

    public MusicCassetteParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.Music = new List<MusicCassetteSettings>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                int id = Convert.ToInt32(token);
                _currentGenreSettings = new MusicCassetteSettings()
                {
                    Id = id,
                };
                _mainGoogleSettings.Music.Add(_currentGenreSettings);
                break;

            case "Name":
                _currentGenreSettings.MusicName = token;
                break;
            case "Audio":
                _currentGenreSettings.Audio = token;
                break;

            case "Description":
                _currentGenreSettings.Description = token;
                break;

            case "MaterialIndex":
                _currentGenreSettings.MaterialIndex = Convert.ToInt32(token);
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }
}
