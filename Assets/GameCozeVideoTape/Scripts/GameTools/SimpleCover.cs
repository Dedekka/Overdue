using UnityEngine;

public class SimpleCover : MonoBehaviour
{
    [SerializeField] private int _currentIDMaterial;

    private static readonly int ArrayIndexProperty = Shader.PropertyToID("_IndexSlice");

    private void OnValidate()
    {
        ChangeMaterial(gameObject, _currentIDMaterial);
    }

    private void ChangeMaterial(GameObject cover, int materialIndex)
    {
        Renderer renderer = cover.GetComponent<Renderer>();
        MaterialPropertyBlock _propertyBlock = new MaterialPropertyBlock();

        UpdateTexture(renderer, _propertyBlock, materialIndex);
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
