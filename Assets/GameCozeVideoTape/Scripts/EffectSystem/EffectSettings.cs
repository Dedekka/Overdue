using UnityEngine;


[CreateAssetMenu(fileName = "EffectSettings", menuName = "Create/Settings/EffectSettings")]
public class EffectSettings : ScriptableObject
{
    #region Public Field

    public Material SelectionOutline => _selectionOutline;
    public Material WrongShelfOutline => _wrongShelfOutline;
    public Material CorrectPosition => _correctPosition;
    public Vector2 SweepPosRange => _sweepPosRange;
    public float SweepMoveSpeed => _sweepMoveSpeed;

    #endregion
    [Header("Outline")]
    [SerializeField] private Material _selectionOutline;

    [Space(20)]
    [SerializeField] private Material _wrongShelfOutline;

    [Header("CorrectPosition")]
    [SerializeField] private Material _correctPosition;
    [SerializeField] private Vector2 _sweepPosRange = new Vector2(-0.5f,0.5f);
    [SerializeField] private float _sweepMoveSpeed = 1;



    public Material[] ControlSelectedOutline(Material[] materials, bool isActive)
    {

        Debug.Log($"materials {materials.Length}");
        if (isActive)
        {
            Material[] newMat = new Material[2];
            newMat[0] = materials[0];
            newMat[1] = _selectionOutline;
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
        Debug.Log($"materials {materials.Length}");
        Material[] newMat = new Material[2];
        newMat[0] = materials[0];
        if (stateInstal == StateInstal.SuccessInstall)
        {
            newMat[1] = _correctPosition;
            materials = newMat;
        }
        else
        {
            newMat[1] = _wrongShelfOutline;
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