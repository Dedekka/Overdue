using System.Collections.Generic;
using UnityEngine;

public class ControlMusicLanguage 
{
    private DataMusicLanguage _dataLanguage;
    private Language _currentLanguage;
    private ControlSettings _controlSettings;

    public ControlMusicLanguage(DataMusicLanguage dataLanguage, ControlSettings controlSettings)
    {
        _dataLanguage = dataLanguage;
        _controlSettings = controlSettings;
    }

    public void GetLanguage(List<AudioItem> cassettes)
    {
        AudioItem tempCassette;
        _currentLanguage = _controlSettings.Language;
        for (int i = 0; i < cassettes.Count; i++)
        {
            tempCassette = cassettes[i];
            tempCassette.SetLanguage(SetLanguage(tempCassette.Id));
        }
    }

    private string SetLanguage(int id)
    {
        MusicLanguage ItemLanguage = _dataLanguage.GetItem(id);
        return ItemLanguage.GetMusicLanguage(_currentLanguage);
    }
}