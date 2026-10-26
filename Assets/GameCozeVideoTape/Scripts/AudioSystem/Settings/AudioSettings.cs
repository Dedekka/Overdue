using FMODUnity;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioSettings", menuName = "Create/Settings/AudioSettings")]
public class AudioSettings : ScriptableObject
{
    #region PublicField
    public EventReference PickUp => _pickUp;
    public EventReference SnapCorrect => _snapCorrect;
    public EventReference SnapWrong => _snapWrong;
    public EventReference Drop => _drop;
    public EventReference DoorOpen => _doorOpen;
    public EventReference Phone_Ring => _phone_Ring;
    public EventReference AudioRecorder_Play => _audioRecorder_Play;
    public EventReference AudioRecorder_ChangeMusic => _audioRecorder_ChangeMusic;
    public EventReference Tv_Install => _tv_Install;
    public EventReference Tv_PickUp => _tv_PickUp;
    public EventReference Present_Drop => _present_Drop;
    public EventReference Scroll => _scroll;
    public EventReference Phone_Down => _phone_Down;
    public EventReference Phone_Up => _phone_Up;
    public EventReference Ui_Select => _ui_Select;
    public EventReference Ui_LoadScene => _ui_LoadScene;
    public EventReference Ui_Slider => _ui_Slider;
    public EventReference Ui_Click => _ui_Click;
    public EventReference Garland_Active => _garland_Active;
    public float TimeWaitSliderSound => _timeWaitSliderSound;

    #endregion
    [Header("Cassette")]
    [SerializeField] private EventReference _pickUp;
    [SerializeField] private EventReference _snapCorrect;
    [SerializeField] private EventReference _snapWrong;
    [SerializeField] private EventReference _drop;
    [SerializeField] private EventReference _scroll;

    [Header("EventAction")]
    [SerializeField] private EventReference _doorOpen;
    [Header("AudioRecorder")]
    [SerializeField] private EventReference _audioRecorder_Play;
    [SerializeField] private EventReference _audioRecorder_ChangeMusic;
    [Header("TV")]
    [SerializeField] private EventReference _tv_PickUp;
    [SerializeField] private EventReference _tv_Install;
    [Header("Present")]
    [SerializeField] private EventReference _present_Drop;
    [Header("Garland")]
    [SerializeField] private EventReference _garland_Active;
    [Header("Phone")]
    [SerializeField] private EventReference _phone_Ring;
    [SerializeField] private EventReference _phone_Down;
    [SerializeField] private EventReference _phone_Up;
    [Header("Ui")]
    [SerializeField] private EventReference _ui_Select;
    [SerializeField] private EventReference _ui_LoadScene;
    [SerializeField] private EventReference _ui_Slider;
    [SerializeField] private EventReference _ui_Click;

    [Header("UiSettings")]
    [SerializeField] private float _timeWaitSliderSound;
}
