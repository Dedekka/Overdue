using UnityEngine;
using UnityEngine.Localization.Settings;

public class ControlSettings
{
    
    public float Sensitivity { get; private set; }
    public Language Language { get; private set; }
    public ControlSettings(SettingsPlayer settingsPlayer)
    {
        Sensitivity = settingsPlayer.MainSensitivity;
    }

    public void ChangeSensitivity(float sensitivity)
    {
        Debug.Log($"Sensitivity:{Sensitivity}");
        Sensitivity = sensitivity;
    }

    public void ChangeLanguage(Language language)
    {
        Debug.Log($"ControlSettings,  Language:{language}, index:{(int)language}");
        Language = language;
    }
}
