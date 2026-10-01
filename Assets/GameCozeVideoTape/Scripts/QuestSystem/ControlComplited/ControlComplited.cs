using System.Collections.Generic;

public class ControlComplited
{
    private List<ComplitedHistoryEvent> _complitedEvents;
    private readonly HistorySystem _historySystem;
    private FactoryComplitedHistoryEvent _factoryComplited;

    private ComplitedHistoryEvent _currentComplitedEvent;
    private int _currentComplitedEvents;

    public ControlComplited(HistorySystem historySystem, FactoryComplitedHistoryEvent factoryComplited)
    {
        _historySystem = historySystem;
        _factoryComplited = factoryComplited;
        _complitedEvents = new List<ComplitedHistoryEvent>();
        _currentComplitedEvents = 0;
    }

    public void Initialization()
    {
        _complitedEvents = _factoryComplited.GetComplitedEvents();
        ChangeComplitedEvents();
        SubHistorySystem();
        //Debug.Log($"_complitedEvents:{_complitedEvents.Count} ");
        //for (int i = 0; i < _complitedEvents.Count; i++)
        //{
        //    Debug.Log($"{_complitedEvents[i].GetType()} Id:{_complitedEvents[i].Id}, IdEventHistory:{_complitedEvents[i].IdEventHistory}");
        //}
    }

    private void SubHistorySystem()
    {
        _historySystem.OnActiveEvent += ProgressComplited;
    }

    private void UnSubHistorySystem()
    {
        _historySystem.OnActiveEvent -= ProgressComplited;
    }

    private void ProgressComplited(BazeEvent BazeEvent)
    {
        int idEventHistory = BazeEvent.IdEventHistory;
        CheckComplited(idEventHistory);
    }

    private void CheckComplited(int idEventHistory)
    {
        if (_currentComplitedEvent == null)
        {
            UnSubHistorySystem();
            return;
        }

        if (_currentComplitedEvent.CheckComplited(idEventHistory))
        {
            _currentComplitedEvent.Complited();
            ChangeComplitedEvents();
        }
    }

    private void ChangeComplitedEvents()
    {
        _currentComplitedEvents++;
        _currentComplitedEvent = _complitedEvents.Find((x) => x.Id == _currentComplitedEvents);

        if (_currentComplitedEvent == null)
        {
            UnSubHistorySystem();
        }
    }
}