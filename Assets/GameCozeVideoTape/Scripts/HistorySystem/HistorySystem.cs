using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Zenject;


public class HistorySystem : IInitializable, IDisposable
{
    private List<BazeEvent> _bazeEvents;
    private DataHistoryEvent _dataHistoryEvent;
    private ControlPhoneAnswer _controlPhoneAnswer;
    private ControlPresentEvent _controlPresentEvent;
    private ControlHistoryEvent _controlHistoryEvent;

    private CancellationTokenSource _cancellationTokenSource;

    private BazeEvent _currentEvent;
    private int _countHistoryEvent;
    private bool _waitCompliteEvent;

    public event Action<BazeEvent> OnActiveEvent;

    public HistorySystem(ControlPhoneAnswer controlPhoneAnswer, ControlGameAnalytics controlGameAnalytics, DataHistoryEvent dataHistoryEvent, ControlPresentEvent controlPresentEvent, ControlHistoryEvent controlHistoryEvent)
    {
        _controlPhoneAnswer = controlPhoneAnswer;
        _dataHistoryEvent = dataHistoryEvent;
        _controlHistoryEvent = controlHistoryEvent;
        _bazeEvents = new List<BazeEvent>();
        _controlPresentEvent = controlPresentEvent;
        _countHistoryEvent = 0;
        _waitCompliteEvent = false;
    }

    public void Initialize()
    {
        SetBazeEvent();
    }

    public void Dispose()
    {
        ControlEndToken();
        _controlPhoneAnswer.OnEventComplited -= ComplitedHistoryEvent;
        //_controlPresentEvent.OnEventComplited -= ComplitedHistoryEvent;
    }

    private void SetBazeEvent()
    {
        _dataHistoryEvent.GetBazeEvent(ref _bazeEvents);
        ChangeCurrentEvent();

        _controlPhoneAnswer.OnEventComplited += ComplitedHistoryEvent;
        //_controlPresentEvent.OnEventComplited += ComplitedHistoryEvent;
    }

    private void ChangeCurrentEvent()
    {
        if (_bazeEvents == null) { return; }
        if (_countHistoryEvent >= _bazeEvents.Count) { return; }
        _currentEvent = _bazeEvents[_countHistoryEvent];
        Debug.Log($"ChangeCurrentEvent:{_currentEvent.IdEventHistory}");
        if (_currentEvent.CountCassette < 0)
        {
            ControlEndToken();
            _cancellationTokenSource = new CancellationTokenSource();
            WaitPresentEvent(_cancellationTokenSource.Token).Forget();
        }
    }

    public void ProgressHistory(int successInstall)
    {
        if (_currentEvent == null)
        {
            ChangeCurrentEvent();
        }
        if (_currentEvent == null) { return; }
        if (_waitCompliteEvent) { return; }
        if (_currentEvent.CountCassette <= successInstall)
        {
            OnActiveEvent?.Invoke(_currentEvent);
            FindEvent(_currentEvent);
        }
    }

    public void ComplitedHistoryEvent()
    {
        Debug.Log($"Complited_CountHistoryEvent:{_countHistoryEvent}");
        _waitCompliteEvent = false;
        _countHistoryEvent++;
        Debug.Log($"UP_CountHistoryEvent:{_countHistoryEvent}");
        ChangeCurrentEvent();
    }

    private void FindEvent(BazeEvent bazeEvent)
    {
        _waitCompliteEvent = true;
        Debug.Log($"FindEvent IdEventHistory:{bazeEvent.IdEventHistory}");
        if (bazeEvent is PresentEvent presentEvent)
        {
            _controlPresentEvent.SetEvent(presentEvent);
            Debug.Log($"PresentEvent , Подарок: {presentEvent.IDPresent}");
            return;
        }

        if (bazeEvent is PhoneEvent PhoneEvent)
        {
            Debug.Log($"PhoneEvent, Звонок: {PhoneEvent.IDDialogue}");
            _controlPhoneAnswer.SetEvent(PhoneEvent);
            return;
        }
        _controlHistoryEvent.SetEvent(bazeEvent);
    }

    private async UniTaskVoid WaitPresentEvent(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        ProgressHistory(0);
    }

    private void ControlEndToken()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
        _cancellationTokenSource = null;
    }

}