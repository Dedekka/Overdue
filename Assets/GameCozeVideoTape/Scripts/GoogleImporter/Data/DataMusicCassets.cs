using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataMusicCassets", menuName = "Create/DataMusicCassets")]
public class DataMusicCassets : ScriptableObject
{
    [SerializeField] private List<MusicCassetteSettings> _itemSettings;
    private Dictionary<int, MusicCassetteSettings> _cassetsData;

    private bool _checkDictionary => _cassetsData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        _itemSettings = mainGoogleSettings.Music;
    }

    //public void GetSettings(List<MusicCassetteSettings> cassettes)
    //{
    //    MusicCassetteSettings tempCassette;
    //    for (int i = 0; i < cassettes.Count; i++)
    //    {
    //        tempCassette = cassettes[i];
    //        //tempCassette.SetSettings(GetItem(tempCassette.Id));
    //    }
    //}

    public MusicCassetteSettings GetItem(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(_itemSettings);
        }
        MusicCassetteSettings tempItem = _cassetsData.TryGetValue(id, out MusicCassetteSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<MusicCassetteSettings> itemSettings)
    {
        _cassetsData = new Dictionary<int, MusicCassetteSettings>();
        foreach (var item in itemSettings)
        {
            _cassetsData.Add(item.Id, item);
        }
    }
}