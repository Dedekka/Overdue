using System.Collections.Generic;
using UnityEngine;

public class DataGenreLanguage : ScriptableObject
{
    [SerializeField] private List<GenreLanguage> itemSettings;
    private Dictionary<int, GenreLanguage> _cassetsData;
    private bool _checkDictionary => _cassetsData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.GenreLanguage;
    }

    public GenreLanguage GetGenreLanguage(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(itemSettings);
        }
        GenreLanguage tempItem = _cassetsData.TryGetValue(id, out GenreLanguage item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<GenreLanguage> itemSettings)
    {
        _cassetsData = new Dictionary<int, GenreLanguage>();
        foreach (var item in itemSettings)
        {
            _cassetsData.Add(item.IdGenre, item);
        }
    }
}