using System.Linq;
using UnityEngine;

public class InstallLevelCover : MonoBehaviour
{
    [SerializeField] private CassetteObject[] _CassetteObject;
    [SerializeField] private DataCassets _dataCassets;

    private static readonly int ArrayIndexProperty = Shader.PropertyToID("_IndexSlice");

    [ContextMenu("InstallCover")]
    private void InstallCover()
    {
        CassetteObject tempCassette;
        _dataCassets.GetSettings(_CassetteObject.ToList());
        
        for (int i = 0; i < _CassetteObject.Length; i++)
        {
            tempCassette = _CassetteObject[i];
            ChangeMaterial(tempCassette);
        }
    }


    private void ChangeMaterial(CassetteObject tempCassette)
    {
        Renderer renderer = tempCassette.GetComponent<Renderer>();
        MaterialPropertyBlock _propertyBlock = new MaterialPropertyBlock();

        UpdateTexture(renderer, _propertyBlock, tempCassette.ItemSettings.MaterialIndex);
    }

    private void UpdateTexture(Renderer renderer, MaterialPropertyBlock _propertyBlock, int materialIndex)
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
