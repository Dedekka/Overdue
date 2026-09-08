using System;
using System.Collections.Generic;

public class DialogsLanguageParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private DialogLanguageSettings _currentitemSettings;

    #region CharDialogs
    private const char _findCharacter = ':';
    private const char _findLine = '#';
    private const char _findNumber = '/';
    private const char _clearLine = '@';
    #endregion

    public DialogsLanguageParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.DialogLanguage = new List<DialogLanguageSettings>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentitemSettings = new DialogLanguageSettings()
                {
                    Id = Convert.ToInt32(token)
                };
                _mainGoogleSettings.DialogLanguage.Add(_currentitemSettings);
                break;

            case "Dialogue_Name":
                _currentitemSettings.DialogueName = token;
                break;

            case "En":
                _currentitemSettings.En_DialogLines = ParserDialogtext(token);
                break;

            case "Rus":
                _currentitemSettings.Rus_DialogLines = ParserDialogtext(token);
                break;

            default:
                throw new Exception($"Invalid header: {headerName}, Cell: {token}");
        }
    }

    private List<DialogLine> ParserDialogtext(string text)
    {
        List<DialogLine> dialogs = new List<DialogLine>();
        DialogLine dialogLine = null;
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
                dialogLine = new DialogLine();
                dialogLine.Character = tempText;
                dialogs.Add(dialogLine);
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
                //Debug.Log($"ParserText, _findNumber tempText:{tempText}");
                dialogLine.IdNumber = Convert.ToInt32(tempText);
                tempText = string.Empty;
                continue;
            }
            tempText += text[i];
        }
        return dialogs;
    }
}