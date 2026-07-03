using UnityEngine;

[CreateAssetMenu(fileName = "SettingsPlayer", menuName = "Create/Settings/SettingsPlayer")]
public class SettingsPlayer : ScriptableObject
{
    #region PublicField
    public LayerMask GroundLayer => _groundLayer;
    public LayerMask LayerInteracteble => _layerInteracteble;
    public float MovementSpeed => _movementSpeed;

    public float GroundPointRadius => _groundPointRadius;
    public float Gravity => _gravity;
    public float SensitivityY => _sensitivityY;
    public float SensitivityX => _sensitivityX;
    public float MainSensitivity => _sensitivity;
    public float CoefficientSensitivityAim => _coefficientSensitivityAim;
    public float CoefficientSpeedMoveForAim => _coefficientSpeedMoveForAim;
    public float StartFieldOfView => _startFieldOfView;
    public float EndFieldOfView => _endFieldOfView;
    public float SpeedChooseView => _speedChooseView;
    public float DistanceInteracteble => _distanceInteracteble;
    public int CountSlotInventory => _countSlotInventory;
    //public float CoefficientSmoothSpeed => _coefficientSmoothSpeed;

    #endregion

    [Header("Settings")]
    [Header("PlayerMove")]
    [SerializeField] private float _movementSpeed = 8f;

    [Header("Physic")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundPointRadius = 0.2f;
    [SerializeField] private float _gravity = -9.8f;

    [Header("PlayerLook")]
    [SerializeField] private float _sensitivityY = 30f;
    [SerializeField] private float _sensitivityX = 30f;
    [Range(0, 2)][SerializeField] private float _sensitivity;

    [Header("PlayerAim")]
    [SerializeField, Range(0, 1)] private float _coefficientSensitivityAim = 0.5f;
    [SerializeField, Range(0, 1)] private float _coefficientSpeedMoveForAim= 0.5f;
    [SerializeField] private float _startFieldOfView = 60f;
    [SerializeField] private float _endFieldOfView = 30f;
    [SerializeField, Min(0.1f)] private float _speedChooseView = 1;

    [Header("PlayerInteracteble")]
    [SerializeField] private LayerMask _layerInteracteble;
    [SerializeField] private float _distanceInteracteble;

    [Header("PlayerInventory")]
    [SerializeField] private int _countSlotInventory = 10;

    //[Header("PlayerControlAnimation")]
    //[SerializeField] private float _coefficientSmoothSpeed;
}
