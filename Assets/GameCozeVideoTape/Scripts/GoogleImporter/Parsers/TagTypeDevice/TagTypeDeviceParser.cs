using System;
using System.Collections.Generic;

public class TagTypeDeviceParser : IGoogleParser
{
    private readonly MainGoogleSettings _mainGoogleSettings;
    private TagTypeDeviceSettings _currentTutorialEventSettings;

    public TagTypeDeviceParser(MainGoogleSettings mainGoogleSettings)
    {
        _mainGoogleSettings = mainGoogleSettings;
        _mainGoogleSettings.TagTypeDeviceSettings = new List<TagTypeDeviceSettings>();
    }


    public void Parse(string headerName, string token)
    {
        switch (headerName)
        {
            case "ID":
                _currentTutorialEventSettings = new TagTypeDeviceSettings()
                {
                    IdTag = Convert.ToInt32(token),
                    UiButtonTexts = new List<UiButtonText>()
                };
                _mainGoogleSettings.TagTypeDeviceSettings.Add(_currentTutorialEventSettings);
                break;

            case "KeyTag":
                _currentTutorialEventSettings.KeyTag = token;
                break;

            case "KeyboardMouse":
                _currentTutorialEventSettings.UiButtonTexts.Add(FindType(token, DeviceType.KeyboardMouse));
                break;
            case "Gamepad":
                _currentTutorialEventSettings.UiButtonTexts.Add(FindType(token, DeviceType.Gamepad));
                break;
            case "GamepadXbox":
                _currentTutorialEventSettings.UiButtonTexts.Add(FindType(token, DeviceType.GamepadXbox));
                break;
            case "GamepadSony":
                _currentTutorialEventSettings.UiButtonTexts.Add(FindType(token, DeviceType.GamepadSony));
                break;
            default:
                throw new Exception($"Invalid header: {headerName}");
        }
    }

    private UiButtonText FindType(string text, DeviceType deviceType)
    {
        return new UiButtonText()
        {
            DeviceType = deviceType,
            Text = text
        };
    }
}