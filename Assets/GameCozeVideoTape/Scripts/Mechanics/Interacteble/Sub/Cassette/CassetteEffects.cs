using DG.Tweening;
using UnityEngine;

public class CassetteEffects
{
    private MeshRenderer _meshRenderer;
    private EffectSettings _effectSettings;
    private MaterialPropertyBlock _propertyBlock;

    private StateInstal _stateInstal;

    private static readonly int ArrayIndexProperty = Shader.PropertyToID("_SweepPos");

    public CassetteEffects(EffectSettings effectSettings)
    {
        _effectSettings = effectSettings;
        _stateInstal = StateInstal.None;
        _propertyBlock = new MaterialPropertyBlock();
    }

    public void Initialization(MeshRenderer meshRenderer)
    {
        _meshRenderer = meshRenderer;
    }

    public void SetSettings(StateInstal stateInstal)
    {
        _stateInstal = stateInstal;
    }

    public void ControlSelectedOutline(bool isActive)
    {
        if (_stateInstal == StateInstal.SuccessInstall) { return; }
        if (_stateInstal == StateInstal.Nothing) { return; }

        var materials = _meshRenderer.materials;
        //Debug.Log($"materials {materials.Length}");
        _meshRenderer.materials = _effectSettings.ControlSelectedOutline(materials, isActive);
    }

    public void Install()
    {
        var materials = _meshRenderer.materials;
        _meshRenderer.materials = _effectSettings.ControlInstallEffect(materials, _stateInstal);
        
        if (_stateInstal == StateInstal.SuccessInstall)
        {
            float sweepPos = _effectSettings.SweepPosRange.y;
            DOTween.To(() => sweepPos, x => sweepPos = x, _effectSettings.SweepPosRange.x, _effectSettings.SweepMoveSpeed)
                .OnUpdate(() => AnimationSuccessInstall(sweepPos))
                .OnComplete(() => ClearEffects())
                .Play();
        }
    }


    public void ClearEffects()
    {
        var materials = _meshRenderer.materials;
        _meshRenderer.materials = _effectSettings.ClearEffects(materials);
    }

    private void AnimationSuccessInstall(float time)
    {
        //Debug.Log($"AnimationSuccessInstall: {time}");
        _meshRenderer.GetPropertyBlock(_propertyBlock);
        _propertyBlock.SetFloat(ArrayIndexProperty, time);
        _meshRenderer.SetPropertyBlock(_propertyBlock);

    }
}

public enum StateInstal
{
    None,
    SuccessInstall,
    Nothing
}