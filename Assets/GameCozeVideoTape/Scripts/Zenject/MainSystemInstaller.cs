using UnityEngine;
using Zenject;

public class MainSystemInstaller : MonoInstaller
{
    [Header("SettingsSound")]
    [SerializeField] private SettingsSound _settingsSound;

    public override void InstallBindings()
    {
        BindSettingsSound();
    }

    private void BindSettingsSound()
    {
        Container.Bind<SettingsSound>()
            .FromInstance(_settingsSound)
            .AsSingle();
    }
}