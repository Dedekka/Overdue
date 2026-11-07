using UnityEngine;
using Zenject;

public class GamepadOtherInstaller : MonoInstaller
{
    [SerializeField] private GamepadSettings _gamepadSettings;
    public override void InstallBindings()
    {
        FindSub();
        BindImporter();
        BindGamepadVibration();
    }

    private void FindSub()
    {
        Container.Bind<GamepadSettings>()
             .FromInstance(_gamepadSettings)
             .AsSingle();
    }

    private void BindGamepadVibration()
    {
        Container.BindInterfacesAndSelfTo<ControlGamepadVibration>()
      .AsSingle();

        Container.BindInterfacesAndSelfTo<ListenerPresentEvent>()
      .AsSingle();

        Container.BindInterfacesAndSelfTo<ListenerFailInstallEvent>()
      .AsSingle();

        Container.BindInterfacesAndSelfTo<ListenerPhoneEvent>()
      .AsSingle();
    }

    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<ImporterPauseSystemGamepadVibration>()
     .AsSingle();
    }
}