using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class ControlHistoryEvent
{
    private BazeEvent _bazeEvent;
    private ControlLogic _сontrolLogic;

    public ControlHistoryEvent(ControlLogic сontrolLogic)
    {
        _сontrolLogic = сontrolLogic;
    }

    public void SetEvent(BazeEvent bazeEvent)
    {
        _bazeEvent = bazeEvent;
        ActiveEvent();
    }

    private void ActiveEvent()
    {
        Debug.Log($"ControlHistoryEvent, IdEventHistory:{_bazeEvent.IdEventHistory}, CountCassette:{_bazeEvent.CountCassette}");
        WaitTimer().Forget();
    }

    private async UniTask WaitTimer()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(10));
        _сontrolLogic.BackMenu();
    }
}