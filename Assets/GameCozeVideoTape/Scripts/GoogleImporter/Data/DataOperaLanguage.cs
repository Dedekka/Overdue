using System.Collections.Generic;
using UnityEngine;


public class DataOperaLanguage : ScriptableObject
{
    [SerializeField] private List<OperaLanguageSettings> itemSettings;
    private Dictionary<int, OperaLanguageSettings> _cassetsData;
    private bool _checkDictionary => _cassetsData == null;


    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.OperaLanguage;
    }

    public OperaLanguageSettings GetItem(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(itemSettings);
        }
        OperaLanguageSettings tempItem = _cassetsData.TryGetValue(id, out OperaLanguageSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<OperaLanguageSettings> itemSettings)
    {
        _cassetsData = new Dictionary<int, OperaLanguageSettings>();
        foreach (var item in itemSettings)
        {
            _cassetsData.Add(item.Id_Cassette, item);
        }
    }
}
