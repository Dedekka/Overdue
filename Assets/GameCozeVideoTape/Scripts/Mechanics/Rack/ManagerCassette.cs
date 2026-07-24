using UnityEngine;

public class ManagerCassette 
{
    private DataCassets _dataCassets;
    private DataLanguage _dataLanguage;
    
    public ManagerCassette (DataCassets dataCassets, DataLanguage dataLanguage)
    {
        _dataCassets = dataCassets;
        _dataLanguage = dataLanguage;
    }

    public ItemSettings GetSettings(int Id)
    {
       return _dataCassets.GetItem(Id);
    }
}