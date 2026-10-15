using UnityEngine;

public class ControlCassetteEffects 
{
    private EffectSettings _effectSettings;

    public ControlCassetteEffects(EffectSettings effectSettings)
    {
        _effectSettings = effectSettings;
    }

    public Material[] ControlSelectedOutline(Material[] materials, bool isActive)
    {

        //Debug.Log($"materials {materials.Length}");
        if (isActive)
        {
            Material[] newMat = new Material[2];
            newMat[0] = materials[0];
            newMat[1] = _effectSettings.SelectionOutline;
            materials = newMat;
        }
        else
        {
            if (materials.Length <= 1) { return materials; }

            materials[1] = null;
        }
        return materials;
    }

    public Material[] ControlInstallEffect(Material[] materials, StateInstal stateInstal)
    {
        //Debug.Log($"materials {materials.Length}");
        Material[] newMat = new Material[2];
        newMat[0] = materials[0];
        if (stateInstal == StateInstal.SuccessInstall)
        {
            newMat[1] = _effectSettings.CorrectPosition;
            materials = newMat;
        }
        else
        {
            newMat[1] = _effectSettings.WrongShelfOutline;
            materials = newMat;
        }
        return materials;
    }

    public Material[] ClearEffects(Material[] materials)
    {
        if (materials.Length <= 1) { return materials; }

        materials[1] = null;
        return materials;
    }
}