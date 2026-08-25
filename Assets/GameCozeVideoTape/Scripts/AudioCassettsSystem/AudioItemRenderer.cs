using System.Collections.Generic;
using UnityEngine;

public class AudioItemRenderer 
{
    private DataMusicCassets _dataMusicCassets;
    private MusicCassetteSettings _musicCassetteSettings;
    private ViewRenderer _viewRenderer;
    private Material _material;

    public AudioItemRenderer(ViewRenderer viewRenderer, Material material, DataMusicCassets dataMusicCassets)
    {
        _viewRenderer = viewRenderer;
        _material = material;
        _dataMusicCassets = dataMusicCassets;
    }

    public void SetCassette(List<AudioItem> listCassette)
    {
        AudioItem tempCassetteObject;
        int materialIndex = 1;
        for (int i = 0; i < listCassette.Count; i++)
        {
            tempCassetteObject = listCassette[i];
            materialIndex = GetMaterialIndex(tempCassetteObject.Id);
            _viewRenderer.Initialization(_material, tempCassetteObject.Body, materialIndex);
        }
    }

    private int GetMaterialIndex(int idAudioItem)
    {
        int materialIndex = 0;

        _musicCassetteSettings = _dataMusicCassets.GetItem(idAudioItem);

        materialIndex = _musicCassetteSettings != null ? _musicCassetteSettings.MaterialIndex : -1;

        if (materialIndex < 0)
        {
            materialIndex = 1;
            Debug.LogError($"Not Found GetMaterialIndex");
        }

        return materialIndex;
    }
}
