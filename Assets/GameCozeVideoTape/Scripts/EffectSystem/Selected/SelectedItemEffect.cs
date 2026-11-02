using UnityEngine;

public class SelectedItemEffect
{
    private MeshRenderer _meshRenderer;
    private ControlCassetteEffects _controlCassetteEffects;
    private MaterialPropertyBlock _propertyBlock;
    private EffectSettings _effectSettings;
    private static readonly int ActionOutlineProperty = Shader.PropertyToID("_UseOutline");
    private static readonly int ColorOutlineProperty = Shader.PropertyToID("_Color");

    public SelectedItemEffect(ControlCassetteEffects controlCassetteEffects, EffectSettings effectSettings)
    {
        _effectSettings = effectSettings;
        _controlCassetteEffects = controlCassetteEffects;
        _propertyBlock = new MaterialPropertyBlock();
    }

    public void Initialization(MeshRenderer meshRenderer)
    {
        _meshRenderer = meshRenderer;
    }

    public void ControlSelectedOutline(bool isActive)
    {
        var materials = _meshRenderer.materials;
        //Debug.Log($"materials {materials.Length}");
        _meshRenderer.materials = _controlCassetteEffects.ControlSelectedOutline(materials, isActive);
    }

    public void ControlActionOutline(Renderer renderer)
    {
        renderer.materials = SetActionOutline(renderer.materials);
        AnimationInstall(renderer);
    }

    public void ClearEffects(Renderer renderer)
    {
        var materials = renderer.materials;
        renderer.materials = _controlCassetteEffects.ClearEffects(materials);
    }

    public void ClearEffects()
    {
        var materials = _meshRenderer.materials;
        _meshRenderer.materials = _controlCassetteEffects.ClearEffects(materials);
    }

    private Material[] SetActionOutline(Material[] materials)
    {
        Material[] newMat = new Material[2];
        newMat[0] = materials[0];
        newMat[1] = _effectSettings.WrongShelfOutline;
        materials = newMat;
        return materials;
    }

    private void AnimationInstall(Renderer renderer)
    {
        renderer.GetPropertyBlock(_propertyBlock);
        _propertyBlock.SetColor(ColorOutlineProperty, _effectSettings.PresentItemColor);
        _propertyBlock.SetFloat(ActionOutlineProperty, 1);
        renderer.SetPropertyBlock(_propertyBlock);
    }
}