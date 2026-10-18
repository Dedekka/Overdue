using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Zenject;

public class AchievementZoneClimbRack : MonoBehaviour
{
    private ControlSteamAchievement _controlSteamAchievement;
    private bool _isActive;

    private void Awake()
    {
        _isActive = false;
    }

    [Inject]
    public void Construct(ControlSteamAchievement controlSteamAchievement, CutsceneBlackScreen cutsceneBlackScreen)
    {
        _controlSteamAchievement = controlSteamAchievement;
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
        _controlSteamAchievement.SetAchievement(DataAchievement.ACHIEVEMENT_31);
        await UniTask.Delay(TimeSpan.FromSeconds(3));
        Destroy(gameObject);
    }
}