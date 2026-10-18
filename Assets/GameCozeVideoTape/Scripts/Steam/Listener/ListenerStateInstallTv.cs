using UnityEngine;
using Zenject;

public class ListenerStateInstallTv : IInitializable
{
    private ControlSteamAchievement _controlSteamAchievement;
    private TV _tv;
    private int _count;
    private int _tempCount;

    public ListenerStateInstallTv(TV tv, ControlSteamAchievement controlSteamAchievement)
    {
        _tv = tv;
        _controlSteamAchievement = controlSteamAchievement;
        _count = 7;
        _tempCount = 0;
    }

    public void Initialize()
    {
        _tv.OnStateInstallTv += OnStateInstallTv;
    }

    private void OnStateInstallTv(bool StateInstall)
    {
        _tempCount++;
        Debug.Log($"OnChangeMusic, _tempCount:{_tempCount}, _count:{_count}");
        if (_tempCount >= _count)
        {
            Success();
        }
    }

    private void Success()
    {
        _tv.OnStateInstallTv -= OnStateInstallTv;
        _controlSteamAchievement.SetAchievement(DataAchievement.ACHIEVEMENT_28);
    }
}

