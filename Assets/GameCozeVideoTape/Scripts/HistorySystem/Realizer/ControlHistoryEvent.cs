using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class ControlHistoryEvent
{
    private BazeEvent _bazeEvent;
    private ControlLogic _сontrolLogic;
    private CutSceneController _cutSceneController;

    public ControlHistoryEvent(ControlLogic сontrolLogic, CutSceneController cutSceneController)
    {
        _сontrolLogic = сontrolLogic;
        _cutSceneController = cutSceneController;
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
    }
}