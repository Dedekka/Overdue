using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Zenject;

public class AchievementZoneReturnBox : MonoBehaviour
{
    [SerializeField] private Transform _teleportedPos;

    private ControlSteamAchievement _controlSteamAchievement;
    private CutsceneBlackScreen _cutsceneBlackScreen;
    private Collider _collider;

    private bool _isActive;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _isActive = false;
    }

    [Inject]
    public void Construct(ControlSteamAchievement controlSteamAchievement, CutsceneBlackScreen cutsceneBlackScreen)
    {
        _controlSteamAchievement = controlSteamAchievement;
        _cutsceneBlackScreen = cutsceneBlackScreen;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player component))
        {
            if (_isActive) { return; }
            _isActive = true;
            TeleportedPlayer(component).Forget();
        }
    }

    private async UniTask TeleportedPlayer(Player player)
    {
        _controlSteamAchievement.SetAchievement(DataAchievement.ACHIEVEMENT_32);
        await UniTask.Delay(TimeSpan.FromSeconds(3));
        _cutsceneBlackScreen.ControlView(true);
        _cutsceneBlackScreen.ActiveBlackScreen(0, 2);
        player.CharacterController.enabled = false;
        player.transform.position = _teleportedPos.position;
        player.CharacterController.enabled = true;
        _isActive = false;
    }
}