using UnityEngine;
using Zenject;

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