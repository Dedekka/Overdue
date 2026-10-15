using UnityEngine;


[CreateAssetMenu(fileName = "EffectSettings", menuName = "Create/Settings/EffectSettings")]
public class EffectSettings : ScriptableObject
{
    #region Public Field

    public Material SelectionOutline => _selectionOutline;
    public Material WrongShelfOutline => _wrongShelfOutline;
    public Material CorrectPosition => _correctPosition;
    public Vector2 SweepPosRange => _sweepPosRange;
    public Vector2 EmissiveStrenghRange => _emissiveStrenghRange;
    public float SweepMoveSpeed => _sweepMoveSpeed;
    public float EmissiveSpeed => _emissiveTime;

    #endregion
    [Header("Outline")]
    [SerializeField] private Material _selectionOutline;

    [Space(20)]
    [SerializeField] private Material _wrongShelfOutline;

    [Header("CorrectPosition")]
    [SerializeField] private Material _correctPosition;
    [SerializeField] private Vector2 _sweepPosRange = new Vector2(-0.5f, 0.5f);
    [SerializeField] private float _sweepMoveSpeed = 1;

    [Header("Garlands")]
    [SerializeField] private Vector2 _emissiveStrenghRange = new Vector2(0f, 2f);
    [SerializeField] private float _emissiveTime = 1;

}