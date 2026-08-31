using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataCassets", menuName = "Create/DataCassets")]
public class DataCassets : ScriptableObject
{
    [SerializeField] private List<ItemSettings> itemSettings;
    private Dictionary<int, ItemSettings> _cassetsData;

    private bool _checkDictionary => _cassetsData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.Items;
    }

    public void GetSettings(List<CassetteObject> cassettes)
    {
        CassetteObject tempCassette;
        int countcassettes;
        int tempcountcassette = 1;
        for (int i = 0; i < cassettes.Count; i++)
        {
            tempCassette = cassettes[i];
                countcassettes = tempCassette.Id;
          
            if (tempCassette.Id>= itemSettings.Count)
            {
                countcassettes = tempcountcassette;
                tempcountcassette++;
            }

            if (tempcountcassette >= itemSettings.Count)
            {
                tempcountcassette = 1;
                countcassettes = tempcountcassette;
            }
            Debug.Log($"tempCassette.Id:{tempCassette.Id}, countcassettes:{countcassettes}, tempcountcassette:{tempcountcassette},  cassettes.Count:{cassettes.Count}");

                tempCassette.SetSettings(GetItem(countcassettes));
        }
    }

    public int GetMaxCassette()
    {
        return itemSettings.Count;
    }

    public ItemSettings GetItem(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(itemSettings);
        }
        ItemSettings tempItem = _cassetsData.TryGetValue(id, out ItemSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<ItemSettings> itemSettings)
    {
        _cassetsData = new Dictionary<int, ItemSettings>();
        foreach (var item in itemSettings)
        {
            _cassetsData.Add(item.Id, item);
        }
    }

}