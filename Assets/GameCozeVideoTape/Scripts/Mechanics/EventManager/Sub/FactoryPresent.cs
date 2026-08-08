using UnityEngine;

public class FactoryPresent 
{
    private DataPresent _dataPresent;
    private Present _prefabPresent;

    public FactoryPresent (Present prefabPresent, DataPresent dataPresent)
    {
        _prefabPresent = prefabPresent;
        _dataPresent = dataPresent;
    }

    public Present GetPresent(int id)
    {
        Present tempPresent = GameObject.Instantiate(_prefabPresent, null);
        tempPresent.SetPresentSettings( _dataPresent.GetPresentSettings(id));

        return tempPresent;
    }
}