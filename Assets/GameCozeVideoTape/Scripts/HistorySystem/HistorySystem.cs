using System;
using UnityEngine;

public class HistorySystem
{
    private EventOne _eventHistoryOne;
    private EventTwo _eventHistoryTwo;

    private int countEventOne = 5;
    private bool _eventOne = false; // Звонок Звук телефон доступен для активации

    private int countEventTwo = 10;
    private bool _eventTwo = false; // Пришел магнитофон

    private int CurrentCountCassette = 0;

    public HistorySystem(EventOne eventHistoryOne, EventTwo eventHistoryTwo)
    {
        _eventHistoryOne = eventHistoryOne;
        _eventHistoryTwo = eventHistoryTwo;
    }

    public void ProgressHistory(int successInstall)
    {
        CurrentCountCassette = successInstall;

        if (_eventTwo && _eventOne) { return; }

        if (!_eventOne)
        {
            CheckEvent(countEventOne, EventOne);
        }

        if (!_eventTwo)
        {
            CheckEvent(countEventTwo, EventTwo);
        }
    }

    private void CheckEvent(int countEvent, Action action)
    {
        if (CurrentCountCassette >= countEvent)
        {
            action?.Invoke();
        }
    }

    private void EventOne()
    {
        _eventOne = true;
        Debug.LogWarning("EventOne");
        _eventHistoryOne.Active();
    }

    private void EventTwo()
    {
        _eventTwo = true;
        Debug.LogWarning("EventTwo");
        _eventHistoryTwo.Active();
    }
}