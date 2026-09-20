using UnityEngine;

[CreateAssetMenu(fileName = "PhoneSettings", menuName = "Create/Settings/PhoneSettings")]
public class PhoneSettings : ScriptableObject
{
    #region PublicField
    public float TimePhoneBody => _timePhoneBody;

    #endregion

    [Header("PickUp")]
    [SerializeField] private float _timePhoneBody = 0.1f;
}
