using UnityEngine;
using Zenject;

public class MainSystemInstaller : MonoInstaller
{
    [Header("SettingsSound")]
    [SerializeField] private SettingsSound _settingsSound;
    [Header("Player")]
    [SerializeField] private SettingsPlayer _settingsPlayer;

    public override void InstallBindings()
    {
        BindSettingsSound();
    }

    private void BindSettingsSound()
    {
        Container.Bind<SettingsSound>()
            .FromInstance(_settingsSound)
            .AsSingle();

        Container.Bind<SettingsPlayer>()
            .FromInstance(_settingsPlayer)
            .AsSingle();

        Container.Bind<ControlSettings>()
            .AsSingle();
    }
}