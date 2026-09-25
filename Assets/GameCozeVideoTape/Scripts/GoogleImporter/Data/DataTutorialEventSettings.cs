using System.Collections.Generic;
using UnityEngine;

public class DataTutorialEventSettings : ScriptableObject
{
    [SerializeField] private List<TutorialEventSettings> itemSettings;
    private Dictionary<int, TutorialEventSettings> _cassetsData;
    private bool _checkDictionary => _cassetsData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.TutorialEventLanguage;
    }

    public TutorialEventSettings GetGenreLanguage(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(itemSettings);
        }
        TutorialEventSettings tempItem = _cassetsData.TryGetValue(id, out TutorialEventSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<TutorialEventSettings> itemSettings)
    {
        _cassetsData = new Dictionary<int, TutorialEventSettings>();
        foreach (var item in itemSettings)
        {
            _cassetsData.Add(item.Id, item);
        }
    }

}
