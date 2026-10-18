using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class ControlHistoryEvent
{
    private ControlSteamAchievement _controlSteamAchievement;
    private BazeEvent _bazeEvent;
    private ControlLogic _сontrolLogic;
    private CutSceneController _cutSceneController;

    public ControlHistoryEvent(ControlLogic сontrolLogic, CutSceneController cutSceneController, ControlSteamAchievement controlSteamAchievement)
    {
        _сontrolLogic = сontrolLogic;
        _cutSceneController = cutSceneController;
        _controlSteamAchievement = controlSteamAchievement;
    }

    public void SetEvent(BazeEvent bazeEvent)
    {
        _bazeEvent = bazeEvent;
        ActiveEvent();
    }

    private void ActiveEvent()
    {
        Debug.Log($"ControlHistoryEvent, IdEventHistory:{_bazeEvent.IdEventHistory}, CountCassette:{_bazeEvent.CountCassette}");
        _cutSceneController.StartCutscene(3);
        _controlSteamAchievement.SetAchievement(DataAchievement.ACHIEVEMENT_3);
    }
}