using UnityEngine;
using UnityEngine.UIElements;

public class CassetteRenderer 
{
    private Renderer _renderer;
    private MaterialPropertyBlock _propertyBlock;
    private Material _material;
    private static readonly int ArrayIndexProperty = Shader.PropertyToID("_IndexSlice");

    public CassetteRenderer(Material material)
    {
        _material = material;
    }

    public void Initialization(Renderer renderer,string material, int MaterialIndex)
    {
        _renderer = renderer;
        _renderer.material = _material;
        _propertyBlock = new MaterialPropertyBlock();

        // Получаем текущий блок свойств
        _renderer.GetPropertyBlock(_propertyBlock);

        // Устанавливаем индекс
        _propertyBlock.SetInteger(ArrayIndexProperty, MaterialIndex);

        // Применяем блок свойств к рендереру
        _renderer.SetPropertyBlock(_propertyBlock);
    }


}