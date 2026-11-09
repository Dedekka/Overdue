using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GamepadInstaller : MonoInstaller
{
    [SerializeField] private GamePadUiSettings _gamePadUiSettings;
    //[SerializeField] private GamepadSettings _gamepadSettings;
    [SerializeField] private List<GameObject> _selectedPanel;
    [SerializeField] private List<GamepadButtonData> _gamepadButtonData;


    public override void InstallBindings()
    {
        FindSub();
        BindGamePadeUI();
        BindInput();
        BindImporter();
        //BindGamepadVibration();
    }

   
    private void FindSub()
    {
        Container.Bind<DataTagTypeDevice>()
             .FromResource(PathConst.DataTagTypeDeviceAsset)
             .AsSingle();

        //Container.Bind<GamepadSettings>()
        //     .FromInstance(_gamepadSettings)
        //     .AsSingle();

        Container.Bind<GamePadUiSettings>()
            .FromInstance(_gamePadUiSettings)
            .AsSingle();
    }


    //private void BindGamepadVibration()
    //{
    //    Container.BindInterfacesAndSelfTo<ControlGamepadVibration>()
    //  .AsSingle();

    //    Container.BindInterfacesAndSelfTo<ListenerPresentEvent>()
    //  .AsSingle();

    //    Container.BindInterfacesAndSelfTo<ListenerFailInstallEvent>()
    //  .AsSingle();
    //    Container.BindInterfacesAndSelfTo<ListenerPhoneEvent>()
    //  .AsSingle();
    //}



    private void BindGamePadeUI()
    {
        Container.BindInterfacesAndSelfTo<GamePadMenu>()
       .AsSingle()
       .WithArguments(_selectedPanel);
        
        Container.BindInterfacesAndSelfTo<GamePadVisibleUi>()
       .AsSingle()
       .WithArguments(_gamepadButtonData);

        Container.BindInterfacesAndSelfTo<ControlGamePadVisible>()
       .AsSingle()
       .WithArguments(_gamepadButtonData);

        //

        Container.BindInterfacesAndSelfTo<GamePadSelecter>()
        .AsSingle();

        Container.Bind<ControlGoalTextIcon>()
        .AsSingle();

        Container.Bind<CheckerTextIconTags>()
        .AsSingle();

        Container.BindInterfacesAndSelfTo<ControlVisibleCursor>()
       .AsSingle();

    }

    private void BindInput()
    {
        Container.BindInterfacesAndSelfTo<MenuInputControl>()
           .AsSingle();
    }

    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<ImporterDeviceGamePadVisibleUi>()
           .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterMenuInputControlDevice>()
         .AsSingle();

       
    }
}
