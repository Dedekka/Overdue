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
    public float PowerJumpAudioSlot => _powerJumpAudioSlot;
    public float PowerJumpReturnAudioSlot => _powerJumpReturnAudioSlot;
    public float TimeJumpAudioSlot => _timeJumpAudioSlot;
    public float TimeJumpReturnAudioSlot => _timeJumpReturnAudioSlot;
    public float TimeCoverPlate => _timeCoverPlate;
    public float TimeButtonPlay => _timeButtonPlay;
    public float DelayOpen => _delayOpen;
    public Vector3 CoverPlateCloset => _coverPlateCloset;
    public Vector3 CoverPlateOpen => _coverPlateOpen;
    public Vector3 StatePlay => _statePlay;
    #endregion

    [Header("LookItem")]
    [SerializeField] private float _timeMove = 0.5f;
    [SerializeField] private float _maxFoVLookItem = 60f;
    [SerializeField] private float _minFoVLookItem = 35f;
    [SerializeField] private float _mainSensitivityRotateItem = 0.1f;
    [SerializeField] private float _sensitivityRotateItemY = 1f;
    [SerializeField] private float _sensitivityRotateItemX = 1f;
    [Header("AudioItemSlot")]
    [SerializeField] private float _powerJumpAudioSlot;
    [SerializeField] private float _powerJumpReturnAudioSlot;
    [SerializeField] private float _timeJumpAudioSlot;
    [SerializeField] private float _timeJumpReturnAudioSlot;
    [Header("AudioRecorderAnimation")]
    [SerializeField] private float _timeCoverPlate = 0.7f;
    [SerializeField] private float _timeButtonPlay = 0.2f;
    [SerializeField] private float _delayOpen = 0.3f;
    [SerializeField] private Vector3 _coverPlateCloset = new Vector3(-90, 0, 0);
    [SerializeField] private Vector3 _coverPlateOpen = new Vector3(-40, 0, 0);
    [SerializeField] private Vector3 _statePlay = new Vector3(0, -0.007f, 0);

}