using System.Collections.Generic;
using UnityEngine;

public class CassetteRenderer 
{
    private ViewRenderer _viewRenderer;
    private Material _material;

    public CassetteRenderer(ViewRenderer viewRenderer, Material material)
    {
        _viewRenderer = viewRenderer;
        _material = material;
    }

    public void SetCassette(List<CassetteObject> listCassette)
    {
        CassetteObject tempCassetteObject;
        for (int i = 0; i < listCassette.Count; i++)
        {
            tempCassetteObject = listCassette[i];
            if (tempCassetteObject is CassetteObjectPromo)
            {
                //tempCassette.SetSettings(itemSettings[0]);
            }
            else
            {
            _viewRenderer.Initialization(_material, tempCassetteObject.gameObject, tempCassetteObject.ItemSettings.MaterialIndex);
                
            }

           
        }
    }
}
