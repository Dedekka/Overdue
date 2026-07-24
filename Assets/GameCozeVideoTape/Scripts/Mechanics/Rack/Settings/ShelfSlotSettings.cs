using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "ShelfSlotSettings", menuName = "Create/Settings/ShelfSlotSettings")]
public class ShelfSlotSettings : ScriptableObject
{
    #region PublicField
    public Ease EaseSuccess => _easeSuccess;
    public Ease EaseNothing => _easeNothing;
    public float TimeSuccess => _timeSuccess;
    public float TimeNothing => _timeNothing;

    #endregion

    [Header("SuccessInstall")]
    [SerializeField] private Ease _easeSuccess;
    [SerializeField] private float _timeSuccess;
    [Header("NothingInstall")]
    [SerializeField] private Ease _easeNothing;
    [SerializeField] private float _timeNothing;
}
