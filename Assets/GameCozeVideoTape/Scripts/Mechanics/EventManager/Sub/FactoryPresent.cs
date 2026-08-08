using UnityEngine;

public class FactoryPresent 
{
    private ViewRenderer _viewRenderer;
    private DataPresent _dataPresent;
    private Present _prefabPresent;
    private Material _material;

    public FactoryPresent (Present prefabPresent, DataPresent dataPresent, ViewRenderer viewRenderer, Material material)
    {
        _prefabPresent = prefabPresent;
        _dataPresent = dataPresent;
        _viewRenderer = viewRenderer;
        _material = material;
    }

    public Present GetPresent(int id)
    {
        Present tempPresent = GameObject.Instantiate(_prefabPresent, null);
        PresentSettings tempPresentSettings = _dataPresent.GetPresentSettings(id);
        tempPresent.SetPresentSettings(tempPresentSettings);
        _viewRenderer.Initialization(_material, tempPresent.gameObject, tempPresentSettings.MaterialIndex);

        return tempPresent;
    }
}