using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FullScreenTutorialKeyParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private FullScreenTutorialKeySettings _currentTutorialEventSettings;
    
    public FullScreenTutorialKeyParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.FullScreenTutorialKeySettings = new List<FullScreenTutorialKeySettings>();
    }
    
    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentTutorialEventSettings = new FullScreenTutorialKeySettings()
                {
                    Id = Convert.ToInt32(token),
                };
                _mainGoogleSettings.FullScreenTutorialKeySettings.Add(_currentTutorialEventSettings);
                break;

            case "KeyHeader":
                _currentTutorialEventSettings.KeyHeader = token;
                break;

            case "KeyBody":
                _currentTutorialEventSettings.KeyBody = token;
                break;
            case "Video":
                _currentTutorialEventSettings.Video = Resources.Load<VideoClip>(token); ;
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }

   
}