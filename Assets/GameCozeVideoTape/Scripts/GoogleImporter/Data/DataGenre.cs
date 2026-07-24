using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataGenre", menuName = "Create/DataGenre")]
public class DataGenre : ScriptableObject
{
    [SerializeField] private List<GenreSettings> itemSettings;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.Genre;
    }
}