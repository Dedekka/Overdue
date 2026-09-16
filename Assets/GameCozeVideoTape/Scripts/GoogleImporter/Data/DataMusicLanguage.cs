using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataMusicLanguage", menuName = "Create/DataMusicLanguage")]
public class DataMusicLanguage : ScriptableObject
{
    [SerializeField] private List<MusicLanguage> itemSettings;
    private Dictionary<int, MusicLanguage> _cassetsData;
    private bool _checkDictionary => _cassetsData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.MusicLanguage;
    }

    public MusicLanguage GetItem(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(itemSettings);
        }
        MusicLanguage tempItem = _cassetsData.TryGetValue(id, out MusicLanguage item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<MusicLanguage> itemSettings)
    {
        _cassetsData = new Dictionary<int, MusicLanguage>();
        foreach (var item in itemSettings)
        {
            _cassetsData.Add(item.Id, item);
        }
    }
}
