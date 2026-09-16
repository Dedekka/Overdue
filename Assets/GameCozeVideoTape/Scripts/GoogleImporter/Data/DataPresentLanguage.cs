using System.Collections.Generic;
using UnityEngine;

public class DataPresentLanguage : ScriptableObject
{
    [SerializeField] private List<PresentLanguageSettings> itemSettings;
    private Dictionary<int, PresentLanguageSettings> _cassetsData;
    private bool _checkDictionary => _cassetsData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.PresentLanguage;
    }

    public PresentLanguageSettings GetItem(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(itemSettings);
        }
        PresentLanguageSettings tempItem = _cassetsData.TryGetValue(id, out PresentLanguageSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<PresentLanguageSettings> itemSettings)
    {
        _cassetsData = new Dictionary<int, PresentLanguageSettings>();
        foreach (var item in itemSettings)
        {
            _cassetsData.Add(item.IdPresent, item);
        }
    }
}