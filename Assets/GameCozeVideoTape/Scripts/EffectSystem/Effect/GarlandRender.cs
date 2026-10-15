using UnityEngine;

public class GarlandRender
{
    private MaterialPropertyBlock _propertyBlock;
    private static readonly int ArrayIndexProperty = Shader.PropertyToID("_EmissiveStrengh");

    public GarlandRender()
    {
        _propertyBlock = new MaterialPropertyBlock();
    }

    public void ChangeLight(Renderer lamp, float EmissiveStrengh)
    {
        //Debug.Log($"EmissiveStrengh - {EmissiveStrengh}");
        lamp.GetPropertyBlock(_propertyBlock);
        _propertyBlock.SetFloat(ArrayIndexProperty, EmissiveStrengh);
        lamp.SetPropertyBlock(_propertyBlock);
    }
}