using UnityEngine;

public class CassetteRenderer 
{
    private Renderer _renderer;
    private MaterialPropertyBlock _propertyBlock;
    private static readonly int ArrayIndexProperty = Shader.PropertyToID("_IndexSlice");

    public void Initialization(Renderer renderer, int Id)
    {
        _renderer = renderer;
        _propertyBlock = new MaterialPropertyBlock();

        // Получаем текущий блок свойств
        _renderer.GetPropertyBlock(_propertyBlock);

        // Устанавливаем индекс
        _propertyBlock.SetInteger(ArrayIndexProperty, Id);

        // Применяем блок свойств к рендереру
        _renderer.SetPropertyBlock(_propertyBlock);
    }
}