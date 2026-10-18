using UnityEngine;
using Zenject;

public class ListenerChangeMusic : IInitializable
{
    private ControlSteamAchievement _controlSteamAchievement;
    private MusicControl _musicControl;
    private int _count;
    private int _tempCount;

    public ListenerChangeMusic(MusicControl musicControl, ControlSteamAchievement controlSteamAchievement)
    {
        _controlSteamAchievement = controlSteamAchievement;
        _musicControl = musicControl;
        _count = 3;
        _tempCount = 0;
    }

    public void Initialize()
    {
        _musicControl.OnChangeMusic += OnChangeMusic;
    }

    private void OnChangeMusic(FMODUnity.EventReference arg1, int arg2)
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
        _musicControl.OnChangeMusic -= OnChangeMusic;
        _controlSteamAchievement.SetAchievement(DataAchievement.ACHIEVEMENT_30);
    }
}