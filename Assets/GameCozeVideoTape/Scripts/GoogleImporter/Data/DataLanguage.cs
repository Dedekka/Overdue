using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataLanguage", menuName = "Create/DataLanguage")]
public class DataLanguage : ScriptableObject
{
    [SerializeField] private List<ItemLanguage> itemSettings;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.Language;
    }
}
