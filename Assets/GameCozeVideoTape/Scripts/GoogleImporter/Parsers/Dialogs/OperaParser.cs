using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Video;

public class OperaParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private OperaSettings _operaSettings;

    #region CharDialogs
    private const char _findCharacter = ':';
    private const char _findLine = '(';
    private const char _findNumber = ')';
    private const char _clearLine = '@';
    #endregion

    public OperaParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.Opera = new List<OperaSettings>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                int id = Convert.ToInt32(token);
                _operaSettings = new OperaSettings()
                {
                    Id = id,
                    OperaName = $"Episode_{id}"
                };
                _mainGoogleSettings.Opera.Add(_operaSettings);
                break;

            case "ID_Cassette":
                _operaSettings.Id_Cassette = Convert.ToInt32(token);
                break;

            case "ID_Slot":
                _operaSettings.Id_Slot = Convert.ToInt32(token);
                break;

            case "Original_Title":
                _operaSettings.Original_Title = token;
                break;

            case "Video":
                _operaSettings.Video = Resources.Load<VideoClip>(token);
                Debug.Log($"PresentsParser, Name:{token}");
                break;
            case "Audio":
                _operaSettings.Audio = token;
                Debug.Log($"PresentsParser, Name:{token}");
                break;
            case "Subtitles":
                _operaSettings.Subtitles = GetSubtitles(token);
                Debug.Log($"PresentsParser, Name:{token}");
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }

    private Subtitles GetSubtitles(string text)
    {
        //List<Subtitles> listSubtitles = new List<Subtitles>();
        Subtitles subtitles = null;
        SubtitlesLine dialogLine = null;
        string tempText = string.Empty;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == _clearLine)
            {
                //Debug.Log($"ParserText, _clearLine tempText:{tempText}");
                tempText = string.Empty;
                continue;
            }

            if (text[i] == _findCharacter)
            {
                //Debug.Log($"ParserText, _findCharacter tempText:{tempText}");
                subtitles = new Subtitles();
                dialogLine = new SubtitlesLine();
                dialogLine.Character = tempText;
                subtitles.DialogLine = dialogLine;
                //listSubtitles.Add(subtitles);
                i++;
                tempText = string.Empty;
                continue;
            }

            if (text[i] == _findLine)
            {
                //Debug.Log($"ParserText, _findLine tempText:{tempText}");
                dialogLine.Line = tempText;
                tempText = string.Empty;
                continue;
            }

            if (text[i] == _findNumber)
            {
                Debug.Log($"OperaParser, TimeStart tempText:{tempText}");
                subtitles.TimeStart = Convert.ToSingle(tempText, CultureInfo.InvariantCulture);
                tempText = string.Empty;
                continue;
            }
            tempText += text[i];
        }
        return subtitles;
    }
}