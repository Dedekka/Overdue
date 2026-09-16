using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataLanguage", menuName = "Create/DataLanguage")]
public class DataLanguage : ScriptableObject
{
    [SerializeField] private List<ItemLanguage> itemSettings;
    private Dictionary<int, ItemLanguage> _cassetsData;
    private bool _checkDictionary => _cassetsData == null;


    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.Language;
    }

    public ItemLanguage GetItem(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(itemSettings);
        }
        ItemLanguage tempItem = _cassetsData.TryGetValue(id, out ItemLanguage item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<ItemLanguage> itemSettings)
    {
        _cassetsData = new Dictionary<int, ItemLanguage>();
        foreach (var item in itemSettings)
        {
            _cassetsData.Add(item.Id, item);
        }
    }
}
