using System;
using UnityEngine;
using Zenject;
using static UnityEngine.InputManagerEntry;

public class RackInstaller : MonoInstaller
{
    [SerializeField] private SettingsLocalization _settingsLocalization;


    public override void InstallBindings()
    {
        BindRackPlateControl();
        FindSub();
        BindPlateRenderer();
    }

    private void BindPlateRenderer()
    {
        Container.Bind<PlateRenderer>()
           .AsSingle();
    }

    private void FindSub()
    {
        Container.Bind<SettingsLocalization>()
       .FromInstance(_settingsLocalization)
       .AsSingle();
    }

    private void BindRackPlateControl()
    {
        Container.BindInterfacesAndSelfTo<RackPlateControl>()
        .AsSingle();


    }
}