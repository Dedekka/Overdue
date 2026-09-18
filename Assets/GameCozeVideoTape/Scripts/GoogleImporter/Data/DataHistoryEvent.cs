using System.Collections.Generic;
using UnityEngine;

public class DataHistoryEvent : ScriptableObject
{
    [SerializeField] private List<HistoryEventSettings> _historyEvent;
    private Dictionary<int, HistoryEventSettings> _historyData;

    private bool _checkDictionary => _historyData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        _historyEvent = mainGoogleSettings.HistoryEvent;
    }

    //public void SetBazeEvent

    public void GetBazeEvent(ref List<BazeEvent> _bazeEvents)
    {
        BazeEvent tempBazeEvent = null;
        HistoryEventSettings historyEventSettings;
        for (int i = 0; i < _historyEvent.Count; i++)
        {
            historyEventSettings = _historyEvent[i];

            if (historyEventSettings.IDDialogue > 0)
            {
                PhoneEvent phoneEvent = new PhoneEvent()
                {
                    CountCassette = historyEventSettings.CountCassette,
                    IDDialogue = historyEventSettings.IDDialogue,
                    IdEventHistory = historyEventSettings.IdEventHistory,
                };
                tempBazeEvent = phoneEvent;
            }
            else if (historyEventSettings.IDCassette > 0)
            {
                PresentEvent presentEvent = new PresentEvent()
                {
                    CountCassette = historyEventSettings.CountCassette,
                    IDCassette = historyEventSettings.IDCassette,
                    IDPresent = historyEventSettings.IDPresent,
                    IdEventHistory = historyEventSettings.IdEventHistory,
                };
                tempBazeEvent = presentEvent;
            }
            else if (historyEventSettings.IDCassette == 0 && historyEventSettings.IDDialogue == 0)
            {
                tempBazeEvent = new BazeEvent()
                {
                    CountCassette = historyEventSettings.CountCassette,
                    IdEventHistory = historyEventSettings.IdEventHistory,
                };
            }
            _bazeEvents.Add(tempBazeEvent);
        }
    }

    public HistoryEventSettings GetItem(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(_historyEvent);
        }
        HistoryEventSettings tempItem = _historyData.TryGetValue(id, out HistoryEventSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<HistoryEventSettings> itemSettings)
    {
        _historyData = new Dictionary<int, HistoryEventSettings>();
        foreach (var item in itemSettings)
        {
            _historyData.Add(item.IdEventHistory, item);
        }
    }
}