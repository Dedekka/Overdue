using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataCassets", menuName = "Create/DataCassets")]
public class DataCassets : ScriptableObject
{
   [SerializeField] private List<ItemSettings> itemSettings;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.Items;
    }

    public ItemSettings GetItem(int id)
    {
        return itemSettings.Find(x => x.Id == id);
    }
}
