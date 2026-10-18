using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuControl : MonoBehaviour
{
   [SerializeField] private Button _buttonFeedbackMenu;
    private ControlSettings _controlSettings;
    private ControlSteamAchievement _controlSteamAchievement;

    [Inject]
    public void Construct(ControlSettings controlSettings, ControlSteamAchievement controlSteamAchievement)
    {
        _controlSettings = controlSettings;
        _controlSteamAchievement = controlSteamAchievement;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.None;

        _buttonFeedbackMenu.gameObject.SetActive(!_controlSettings.IsComplitedFeedback);
        
        Debug.Log($"Steam Inst:{SteamManager.Initialized}");
# if UNITY_EDITOR
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_1);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_2);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_3);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_4);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_5);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_6);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_7);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_8);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_9);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_10);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_11);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_12);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_13);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_14);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_15);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_16);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_17);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_18);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_19);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_20);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_21);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_22);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_23);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_24);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_25);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_26);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_27);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_28);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_29);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_30);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_31);
        _controlSteamAchievement.ClearAchievement(DataAchievement.ACHIEVEMENT_32);

#endif
    }
}