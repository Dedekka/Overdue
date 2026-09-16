using ModestTree;
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
        string tempName;
        ItemLanguage ItemLanguage = _dataLanguage.GetItem(id);

        if (ItemLanguage == null)
        {
            tempName =  "Cassette";
            return tempName;
        }

        tempName = ItemLanguage.GetLanguage(_currentLanguage);
         tempName = tempName == null ? "Cassette" : tempName;
        return tempName;
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