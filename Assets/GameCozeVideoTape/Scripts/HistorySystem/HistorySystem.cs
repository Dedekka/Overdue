using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HistorySystem : IInitializable, IDisposable
{
    private List<BazeEvent> _bazeEvents;
    private DataHistoryEvent _dataHistoryEvent;
    private ControlPhoneAnswer _controlPhoneAnswer;
    private ControlPresentEvent _controlPresentEvent;
    private ControlHistoryEvent _controlHistoryEvent;

    private BazeEvent _currentEvent;
    private int _countHistoryEvent;

    // Устанавливается диалог что будет играть при воспроизведении
    // если прошлый диалог еще не отиграл то новый встает в очередь на воспроизведение
    // мы не запускаем следующее событие если не было использовано предыдущее 

    //private EventOne _eventHistoryOne;
    //private EventTwo _eventHistoryTwo;

    //private int countEventOne = 5;
    //private bool _eventOne = false; // Звонок Звук телефон доступен для активации

    //private int countEventTwo = 10;
    //private bool _eventTwo = false; // Пришел магнитофон

    //private int CurrentCountCassette = 0;

    public HistorySystem(ControlPhoneAnswer controlPhoneAnswer, DataHistoryEvent dataHistoryEvent, ControlPresentEvent controlPresentEvent, ControlHistoryEvent controlHistoryEvent)
    {
        _controlPhoneAnswer = controlPhoneAnswer;
        _dataHistoryEvent = dataHistoryEvent;
        _controlHistoryEvent = controlHistoryEvent;
        _bazeEvents = new List<BazeEvent>();
        _controlPresentEvent = controlPresentEvent;
        _countHistoryEvent = 0;
    }

    public void Initialize()
    {
        SetBazeEvent();
    }

    public void Dispose()
    {
        _controlPhoneAnswer.OnEventComplited -= ComplitedHistoryEvent;
        _controlPresentEvent.OnEventComplited -= ComplitedHistoryEvent;
    }

    private void SetBazeEvent()
    {
        _dataHistoryEvent.GetBazeEvent(ref _bazeEvents);
        ChangeCurrentEvent();

        _controlPhoneAnswer.OnEventComplited += ComplitedHistoryEvent;
        _controlPresentEvent.OnEventComplited += ComplitedHistoryEvent;

        //BazeEvent tempBazeEvent;
        //Debug.Log($"HistorySystem, CountEvent:{_bazeEvents.Count}");
        //for (int i = 0; i < _bazeEvents.Count; i++)
        //{
        //    tempBazeEvent = _bazeEvents[i];
        //    Debug.Log($"IdEventHistory: {tempBazeEvent.IdEventHistory}, CountCassette: {tempBazeEvent.CountCassette}");
        //    if (tempBazeEvent is PresentEvent presentEvent)
        //    {
        //        tempBazeEvent = presentEvent;
        //        Debug.Log($"SetBazeEvent Type:{presentEvent.GetType()}, IDPresent: {presentEvent.IDPresent}");
        //    }

        //    if (tempBazeEvent is PhoneEvent PhoneEvent)
        //    {
        //        Debug.Log($"SetBazeEvent Type:{PhoneEvent.GetType()}, IDDialogue: {PhoneEvent.IDDialogue}");
        //    }
        //}
    }

    private void ChangeCurrentEvent()
    {
        if (_bazeEvents == null) { return; }
        if (_countHistoryEvent >= _bazeEvents.Count) { return; }
        _currentEvent = _bazeEvents[_countHistoryEvent];
        Debug.Log($"ChangeCurrentEvent:{_currentEvent.IdEventHistory}");
    }

    public void ProgressHistory(int successInstall)
    {
        if (_currentEvent == null)
        {
            ChangeCurrentEvent();
        }

        if (_currentEvent == null) { return; }
        if (_currentEvent.CountCassette <= successInstall)
        {
            FindEvent(_currentEvent);
        }
    }

    public void ComplitedHistoryEvent()
    {
        Debug.Log($"Complited_CountHistoryEvent:{_countHistoryEvent}");
        _countHistoryEvent++;
        Debug.Log($"UP_CountHistoryEvent:{_countHistoryEvent}");
        ChangeCurrentEvent();
    }

    private void FindEvent(BazeEvent bazeEvent)
    {
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

    //private void CheckEvent(int countEvent, Action action)
    //{
    //    if (CurrentCountCassette >= countEvent)
    //    {
    //        action?.Invoke();
    //    }
    //}

    //private void EventOne()
    //{
    //    _eventOne = true;
    //    Debug.LogWarning("EventOne");
    //    _eventHistoryOne.Active();
    //}

    //private void EventTwo()
    //{
    //    _eventTwo = true;
    //    Debug.LogWarning("EventTwo");
    //    _eventHistoryTwo.Active();
    //}
}