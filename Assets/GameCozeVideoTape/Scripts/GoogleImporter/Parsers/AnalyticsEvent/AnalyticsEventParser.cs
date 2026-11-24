using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AnalyticsEventParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private AnalyticsEventSettings _currentTutorialEventSettings;

    public AnalyticsEventParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.AnalyticsEventSettings = new List<AnalyticsEventSettings>();
    }

    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentTutorialEventSettings = new AnalyticsEventSettings()
                {
                    Id = Convert.ToInt32(token),
                };
                _mainGoogleSettings.AnalyticsEventSettings.Add(_currentTutorialEventSettings);
                break;

            case "Name":
                _currentTutorialEventSettings.NameEvent = token;
                break;

            case "Description":
                _currentTutorialEventSettings.DescriptionEvent = token;
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }
}