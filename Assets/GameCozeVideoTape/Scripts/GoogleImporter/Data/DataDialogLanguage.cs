using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataLanguage", menuName = "Create/DataLanguage")]
public class DataDialogLanguage : ScriptableObject
{
    [SerializeField] private List<DialogLanguageSettings> itemSettings;
    private Dictionary<int, DialogLanguageSettings> _cassetsData;
    private bool _checkDictionary => _cassetsData == null;


    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.DialogLanguage;
    }

    public DialogLanguageSettings GetItem(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(itemSettings);
        }
        DialogLanguageSettings tempItem = _cassetsData.TryGetValue(id, out DialogLanguageSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<DialogLanguageSettings> itemSettings)
    {
        _cassetsData = new Dictionary<int, DialogLanguageSettings>();
        foreach (var item in itemSettings)
        {
            _cassetsData.Add(item.Id, item);
        }
    }
}
