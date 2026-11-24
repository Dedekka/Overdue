using System.Collections.Generic;
using UnityEngine;

public class DataAnalyticsEvent : ScriptableObject, IDatable
{
    [SerializeField] private List<AnalyticsEventSettings> itemSettings;
    private Dictionary<int, AnalyticsEventSettings> _cassetsData;

    private bool _checkDictionary => _cassetsData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.AnalyticsEventSettings;
    }

    public AnalyticsEventSettings GetAnalyticsEvent(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(itemSettings);
        }
        AnalyticsEventSettings tempItem = _cassetsData.TryGetValue(id, out AnalyticsEventSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<AnalyticsEventSettings> itemSettings)
    {
        _cassetsData = new Dictionary<int, AnalyticsEventSettings>();
        foreach (var item in itemSettings)
        {
            _cassetsData.Add(item.Id, item);
        }
    }

}