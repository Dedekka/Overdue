using System.Collections.Generic;
using UnityEditor.Rendering;
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