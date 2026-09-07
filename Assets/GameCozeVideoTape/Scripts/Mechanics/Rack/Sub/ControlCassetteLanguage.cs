using System.Collections.Generic;

public class ControlCassetteLanguage
{
    private DataLanguage _dataLanguage;
    private Language _currentLanguage;

    public ControlCassetteLanguage(DataLanguage dataLanguage)
    {
        _dataLanguage = dataLanguage;
        _currentLanguage = Language.En;
    }

    public void GetLanguage(List<CassetteObject> cassettes)
    {
        CassetteObject tempCassette;
        for (int i = 0; i < cassettes.Count; i++)
        {
            tempCassette = cassettes[i];
            tempCassette.SetLanguage(SetLanguage(tempCassette.Id));
        }
    }

    private string SetLanguage(int id)
    {
        ItemLanguage ItemLanguage = _dataLanguage.GetItem(id);

        return ItemLanguage.En;
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