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
    #endregion

    [Header("Audio")]
    [SerializeField] private EventReference _pickUp;
    [SerializeField] private EventReference _snapCorrect;
    [SerializeField] private EventReference _snapWrong;
    [SerializeField] private EventReference _drop;
}
