using UnityEngine;

[CreateAssetMenu(fileName = "GamepadSettings", menuName = "Create/Settings/GamepadSettings")]
public class GamepadSettings : ScriptableObject
{
    #region
    public Vector2 ForceVibrationPresent => _forceVibrationPresent;
    public Vector2 ForceVibrationInstallSuccess => _forceVibrationInstallSuccess;
    public Vector2 ForceVibrationInstallFail => _forceVibrationInstallFail;
    public float DurationVibrationPresent => _durationVibrationPresent;
    public float DurationVibrationInstallSuccess => _durationVibrationInstallSuccess;
    public float DurationVibrationInstallFail => _durationVibrationInstallFail;
    public float RangeVibrationPhone => _rangeVibrationPhone;
    public float TimeVibration => _timeVibration;
    public float TimeWaitWaiting => _timeWaitWaiting;
    public float MaxForceVibration => _maxForceVibration;

    #endregion
    [Header("Present")]
    [SerializeField] private Vector2 _forceVibrationPresent;
    [SerializeField] private float _durationVibrationPresent;
    [Header("Phone")]
    [SerializeField] private float _rangeVibrationPhone;// Дистанция вибрации контроллера когда звонит телефон
    [SerializeField] private float _timeVibration = 1f;
    [SerializeField] private float _timeWaitWaiting = 1.5f;
    [SerializeField] private float _maxForceVibration = 0.8f;
    [Header("Install")]
    [SerializeField] private Vector2 _forceVibrationInstallSuccess;
    [SerializeField] private float _durationVibrationInstallSuccess;
    [SerializeField] private Vector2 _forceVibrationInstallFail;
    [SerializeField] private float _durationVibrationInstallFail;
}
