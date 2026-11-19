using System.IO;

public class ControlSteamState
{
    private const string State = "steam_display";

    public void SetPlayerState(string playerState)
    {
        Steamworks.SteamFriends.SetRichPresence(State, playerState);
    }
}