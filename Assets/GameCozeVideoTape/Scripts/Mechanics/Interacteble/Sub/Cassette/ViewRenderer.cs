using UnityEngine;
using UnityEngine.UIElements;

public class ViewRenderer 
{
    private Renderer _renderer;
    private MaterialPropertyBlock _propertyBlock;
    private static readonly int ArrayIndexProperty = Shader.PropertyToID("_IndexSlice");

    public void Initialization(Material material, GameObject gameObject, int MaterialIndex)
    {
        TryGetRenderer(gameObject);
        
        _renderer.material = material;
        _propertyBlock = new MaterialPropertyBlock();

        // Получаем текущий блок свойств
        _renderer.GetPropertyBlock(_propertyBlock);

        // Устанавливаем индекс
        _propertyBlock.SetInteger(ArrayIndexProperty, MaterialIndex);

        // Применяем блок свойств к рендереру
        _renderer.SetPropertyBlock(_propertyBlock);
    }

    private void TryGetRenderer(GameObject gameObject)
    {
        _renderer = gameObject.GetComponent<Renderer>();
        if (_renderer == null)
        {
            _renderer = gameObject.GetComponentInChildren<Renderer>();
        }
    }
}