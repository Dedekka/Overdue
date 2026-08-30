using System.Collections.Generic;
using UnityEngine;

public class AudioItemRenderer 
{
    private ViewRenderer _viewRenderer;
    private Material _material;

    public AudioItemRenderer(ViewRenderer viewRenderer, Material material)
    {
        _viewRenderer = viewRenderer;
        _material = material;
    }

    public void SetCassette(List<AudioItem> listCassette)
    {
        AudioItem tempCassetteObject;
        int materialIndex = 1;
        for (int i = 0; i < listCassette.Count; i++)
        {
            tempCassetteObject = listCassette[i];
            materialIndex = tempCassetteObject.MusicCassetteSettings.MaterialIndex;
            _viewRenderer.Initialization(_material, tempCassetteObject.Body, materialIndex);
        }
    }
}