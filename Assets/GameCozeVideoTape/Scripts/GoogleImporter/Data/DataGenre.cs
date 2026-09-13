using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataGenre", menuName = "Create/DataGenre")]
public class DataGenre : ScriptableObject
{
    [SerializeField] private List<GenreSettings> _genreSettings;
    private Dictionary<int, GenreVideo> _genreVideoDictionary;

    private bool _checkDictionary => _genreVideoDictionary == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        _genreSettings = mainGoogleSettings.Genre;
    }

    public GenreVideo GetGenreVideo(int idCassette)
    {
        if (_checkDictionary)
        {
            SetDictionary(_genreSettings);
        }
        GenreVideo tempItem = _genreVideoDictionary.TryGetValue(idCassette, out GenreVideo item) ? item : null;
        return tempItem;
    }

    public GenreSettings GetGenreSettingsForId(int idGenre)
    {
        GenreSettings tempItem = _genreSettings.Find((x) => x.IdGenre == idGenre);
        return tempItem;
    }

    public SubGenreSettings GetSubGenreSettingsForId(int idGenre, int idSubGenre)
    {
        GenreSettings tempGenre = _genreSettings.Find((x) => x.IdGenre == idGenre);
        SubGenreSettings tempSubGenre = tempGenre.SubGenreList.Find((x) => x.IdSubGenre == idSubGenre);
        return tempSubGenre;
    }




    private void SetDictionary(List<GenreSettings> itemSettings)
    {
        _genreVideoDictionary = new Dictionary<int, GenreVideo>();
        foreach (var item in itemSettings)
        {
            _genreVideoDictionary.Add(item.IdGenre, item.GenreVideo);
        }
    }
}

