using Steamworks;
using UnityEngine;

public class ControlSteamAchievement 
{
    private bool _isActiveSteam;
    private bool _isClearAchievement;
    private bool _isSetAchievement;
    private bool _isStoreState;

    public void SetAchievement(string name)
    {
        _isSetAchievement = Steamworks.SteamUserStats.SetAchievement(name);
        Debug.Log($"Achievement:{name}, SetAchievement:{_isSetAchievement}");
        StoreState();
    }
     
    //private void Start()
    //{
    //    RequestStats();
    //    ClearAchievement(DataAchievement.ACHIEVEMENT_1);
    //    //SetAchievement(DataAchievement.ACHIEVEMENT_1);
    //}

    private void RequestStats()
    {
        _isActiveSteam = SteamManager.Initialized;
        Debug.Log($"IsActiveSteam:{_isActiveSteam}");
    }

    public void ClearAchievement(string name)
    {
        _isClearAchievement = Steamworks.SteamUserStats.ClearAchievement(name);
        Debug.Log($"Achievement:{name}, IsClearAchievement:{_isClearAchievement}");
        StoreState();
    }

    private void StoreState()
    {
        _isStoreState = Steamworks.SteamUserStats.StoreStats();
        Debug.Log($"StoreState:{_isStoreState}");
    }
}