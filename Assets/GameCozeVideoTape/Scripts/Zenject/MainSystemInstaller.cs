using System;
using UnityEngine;
using Zenject;

public class MainSystemInstaller : MonoInstaller
{
    [Header("SettingsSound")]
    [SerializeField] private SettingsSound _settingsSound;
    [Header("Player")]
    [SerializeField] private SettingsPlayer _settingsPlayer;

    [Header("Steam")]
    [SerializeField] private SteamManager _steamManager;


    public override void InstallBindings()
    {
        BindSettingsSound();
        BindControlLogic();
        BindSteam();
    }

    private void BindSteam()
    {
        Container.Bind<SteamManager>()
        .FromInstance(_steamManager)
        .AsSingle();

        Container.Bind<ControlSteamAchievement>()
            .AsSingle();
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


    private void BindControlLogic()
    {
        Container.Bind<ControlLogic>()
            .AsSingle();

        //Container.Bind<ControlSound>()
        //    .AsSingle();

        Container.Bind<LoadingSystem>()
            .AsSingle();
    }
}