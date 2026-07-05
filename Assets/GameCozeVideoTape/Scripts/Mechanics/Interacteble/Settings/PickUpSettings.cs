using UnityEngine;


[CreateAssetMenu(fileName = "PickUpSettings", menuName = "Create/Settings/PickUpSettings")]
public class PickUpSettings : ScriptableObject
{
    #region PublicField
    public float SpeedBlend => _speedBlend;
    public float CoeffBlend => _coeffBlend;
    public float MinDistance => _minDistance;
    public float MinRotation => _minRotation;

    #endregion

    [Header("PickUp")]
    [SerializeField] private float _speedBlend = 2f;
    [SerializeField] private float _coeffBlend = 1.2f;
    [SerializeField] private float _minDistance = 0f;
    [SerializeField] private float _minRotation = 0.5f;
}
