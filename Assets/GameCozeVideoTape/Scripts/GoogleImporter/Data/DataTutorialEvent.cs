using System.Collections.Generic;
using UnityEngine;

public class DataTutorialEvent : ScriptableObject
{
    [SerializeField] private List<TutorialEventSettings> _tutorialEventSettings;
    private Dictionary<int, TutorialEventSettings> _cassetsData;

    private bool _checkDictionary => _cassetsData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        _tutorialEventSettings = mainGoogleSettings.TutorialEvent;
    }

    public int GetCount()
    {
        return _tutorialEventSettings.Count;
    }

    public TutorialEventSettings GetTutorialEventSettings(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(_tutorialEventSettings);
        }
        TutorialEventSettings tempItem = _cassetsData.TryGetValue(id, out TutorialEventSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<TutorialEventSettings> tutorialEventSettings)
    {
        _cassetsData = new Dictionary<int, TutorialEventSettings>();
        foreach (var item in tutorialEventSettings)
        {
            _cassetsData.Add(item.Id, item);
        }
    }
}
