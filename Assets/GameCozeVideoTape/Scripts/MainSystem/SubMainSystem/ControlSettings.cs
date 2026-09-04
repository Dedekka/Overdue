using UnityEngine;

public class ControlSettings
{
    public float Sensitivity { get; private set; }
    public ControlSettings(SettingsPlayer settingsPlayer)
    {
        Sensitivity = settingsPlayer.MainSensitivity;
    }

    public void ChangeSensitivity(float sensitivity)
    {
        Debug.Log($"Sensitivity:{Sensitivity}");
        Sensitivity = sensitivity;
    }
}