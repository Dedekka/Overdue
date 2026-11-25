using System.IO;
using UnityEngine;

public class ControlSteamState 
{
    public void SetPlayerState(string keyStatus)
    {
        if (!SteamManager.Initialized) { return; }
       

        if (Steamworks.SteamFriends.SetRichPresence("steam_display", keyStatus))
        {
            Debug.LogWarning($"Active - {keyStatus}");
        }
        else
        {
            Debug.LogWarning($"No Active - {keyStatus}");
        }
    }

    public void SetCountInstall(string keyStatus)
    {
        if (!SteamManager.Initialized) { return; }
        if (Steamworks.SteamFriends.SetRichPresence("Count", keyStatus))
        {
            Debug.LogWarning($"Active - {keyStatus}");
        }
        else
        {
            Debug.LogWarning($"No Active - {keyStatus}");
        }
    }


}