using System.Collections.Generic;
using UnityEngine;

public class DataTutorialEventLanguage : ScriptableObject
{
    [SerializeField] private List<TutorialEventLanguageSettings> itemSettings;
    private Dictionary<int, TutorialEventLanguageSettings> _cassetsData;
    private bool _checkDictionary => _cassetsData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.TutorialEventLanguage;
    }

    public TutorialEventLanguageSettings GetLanguage(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(itemSettings);
        }
        TutorialEventLanguageSettings tempItem = _cassetsData.TryGetValue(id, out TutorialEventLanguageSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<TutorialEventLanguageSettings> itemSettings)
    {
        _cassetsData = new Dictionary<int, TutorialEventLanguageSettings>();
        foreach (var item in itemSettings)
        {
            _cassetsData.Add(item.Id, item);
        }
    }

}
