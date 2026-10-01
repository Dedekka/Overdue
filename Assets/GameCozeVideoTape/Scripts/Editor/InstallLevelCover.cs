using System.Linq;
using UnityEditor;
using UnityEngine;

public class InstallLevelCover : EditorWindow
{
    private static CassetteObject[] _сassetteObjects;
    private static DataCassets _dataCassets;

    private static readonly int ArrayIndexProperty = Shader.PropertyToID("_IndexSlice");

    //Container.Bind<DataCassets>()
    //       .FromResource(PathConst.DataCassetsAsset)
    //       .AsSingle();

    [MenuItem("Tools/InstallTexture/Cassette")]
    private static void InstallCover()
    {
        FindSub();

        CassetteObject tempCassette;
        _dataCassets.GetSettings(_сassetteObjects.ToList());
        
        for (int i = 0; i < _сassetteObjects.Length; i++)
        {
            tempCassette = _сassetteObjects[i];
            ChangeMaterial(tempCassette);
        }
    }

    private static void FindSub()
    {
        _сassetteObjects = GameObject.FindObjectsByType<CassetteObject>(FindObjectsSortMode.None);
        _dataCassets = Resources.Load<DataCassets>(PathConst.DataCassetsAsset);
    }

    private static void ChangeMaterial(CassetteObject tempCassette)
    {
        Renderer renderer = tempCassette.GetComponent<Renderer>();
        MaterialPropertyBlock _propertyBlock = new MaterialPropertyBlock();

        UpdateTexture(renderer, _propertyBlock, tempCassette.ItemSettings.MaterialIndex);
    }

    private static void UpdateTexture(Renderer renderer, MaterialPropertyBlock _propertyBlock, int materialIndex)
    {
        // Получаем текущий блок свойств
        renderer.GetPropertyBlock(_propertyBlock);

        // Устанавливаем индекс
        //_propertyBlock.SetTexture(IndexTextureProperty, _cover);
        _propertyBlock.SetInteger(ArrayIndexProperty, materialIndex);

        // Применяем блок свойств к рендереру
        renderer.SetPropertyBlock(_propertyBlock);
    }
}
