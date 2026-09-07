using System.Collections.Generic;

public class ControlCassetteLanguage
{
    private DataLanguage _dataLanguage;
    private Language _currentLanguage;
    private ControlSettings _controlSettings;

    public ControlCassetteLanguage(DataLanguage dataLanguage, ControlSettings controlSettings)
    {
        _dataLanguage = dataLanguage;
        _controlSettings = controlSettings;
    }

    public void GetLanguage(List<CassetteObject> cassettes)
    {
        CassetteObject tempCassette;
        _currentLanguage = _controlSettings.Language;
        for (int i = 0; i < cassettes.Count; i++)
        {
            tempCassette = cassettes[i];
            tempCassette.SetLanguage(SetLanguage(tempCassette.Id));
        }
    }

    private string SetLanguage(int id)
    {
        ItemLanguage ItemLanguage = _dataLanguage.GetItem(id);
       return ItemLanguage.GetLanguage(_currentLanguage);
        //return ItemLanguage.En;
    }
}

public enum Language
{
    En,
    Ru,
    DE,
    ES,
    JPN,
    ZHCN
}