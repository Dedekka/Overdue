using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private DialogSettings _currentDialogueEventData;

    #region CharDialogs
    private const char _findCharacter = ':';
    private const char _findLine = '#';
    private const char _findNumber = '/';
    private const char _clearLine = '@';
    #endregion

    #region CharSound
    private const char _clearSound = '#';
    private const char _findNumberSound = ' ';
    private const char _findPath = '@';
    #endregion

    public DialogueParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.Dialogues = new List<DialogSettings>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentDialogueEventData = new DialogSettings()
                {
                    Id = Convert.ToInt32(token)
                };
                
                _currentDialogueEventData.DialogueEventData = _mainGoogleSettings.DialogueEvent.Find((x) => x.IdEvent == _currentDialogueEventData.Id);
                _mainGoogleSettings.Dialogues.Add(_currentDialogueEventData);
                break;

            case "Dialogue_Name":
                _currentDialogueEventData.DialogueName = token;
               
                break;
            case "Сharacter":
                _currentDialogueEventData.NameCharacter = token;
                break;
            case "Оригинальное название":
                _currentDialogueEventData.Original_Title = token;
                break;
            case "Подарок":
                _currentDialogueEventData.Present = token;
                break;

            case "Диалог":

                _currentDialogueEventData.DialogLines = ParserDialogtext(token);
                break;

            case "Sound":
                _currentDialogueEventData.DialogLines = ParserDialogSound(_currentDialogueEventData.DialogLines, token);
                break;


            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }

    private List<DialogLine> ParserDialogSound(List<DialogLine> dialogLines, string fmodPath)
    {
        List<SoundLine> soundLines = new List<SoundLine>();
        SoundLine soundLine = null;
        string tempText = string.Empty;
        for (int i = 0; i < fmodPath.Length; i++)
        {
            if (fmodPath[i] == _clearSound)
            {
                //Debug.Log($"ParserDialogSound, _clearLine tempText:{tempText}");
                tempText = string.Empty;
                continue;
            }

            if (fmodPath[i] == _findNumberSound)
            {
                //Debug.Log($"ParserDialogSound, _findCharacter tempText:{tempText}");
                soundLine = new SoundLine();
                soundLine.IdLine = tempText;
                soundLines.Add(soundLine);
                tempText = string.Empty;
                continue;
            }

            if (fmodPath[i] == _findPath)
            {
                //Debug.Log($"ParserText, _findNumber tempText:{tempText}");


                //EventReference tempEvent = RuntimeManager.PathToEventReference(tempText);

                soundLine.PathFmod = tempText;
                tempText = string.Empty;
                continue;
            }
            tempText += fmodPath[i];
        }

        for (int i = 0; i < dialogLines.Count; i++)
        {
            dialogLines[i].SoundLine = soundLines[i].PathFmod;
        }

        return dialogLines;

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