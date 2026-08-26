using UnityEngine;

[CreateAssetMenu(fileName = "SettingsLookItem", menuName = "Create/Settings/SettingsLookItem")]
public class SettingsLookItem : ScriptableObject
{
    #region PublicField
    public float MainSensitivityRotateItem => _mainSensitivityRotateItem;
    public float SensitivityRotateItemY => _sensitivityRotateItemY;
    public float SensitivityRotateItemX => _sensitivityRotateItemX;
    public float MaxFoVLookItem => _maxFoVLookItem;
    public float MinFoVLookItem => _minFoVLookItem;
    public float TimeMove => _timeMove;
    #endregion

    [Header("LookItem")]
    [SerializeField] private float _timeMove = 0.5f;
    [SerializeField] private float _maxFoVLookItem = 60f;
    [SerializeField] private float _minFoVLookItem = 35f;
    [SerializeField] private float _mainSensitivityRotateItem = 0.1f;
    [SerializeField] private float _sensitivityRotateItemY = 1f;
    [SerializeField] private float _sensitivityRotateItemX = 1f;
}