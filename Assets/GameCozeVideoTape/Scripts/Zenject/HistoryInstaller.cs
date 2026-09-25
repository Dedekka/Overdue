using System;
using Zenject;

public class HistoryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        FindSub();
        BindHistorySystem();
      
        BindImporter();
    }

    private void FindSub()
    {
        Container.Bind<DataHistoryEvent>()
           .FromResource(PathConst.DataHistoryEventAsset)
           .AsSingle();
    }

    private void BindHistorySystem()
    {
        Container.BindInterfacesAndSelfTo<HistorySystem>()
       .AsSingle();

        Container.BindInterfacesAndSelfTo<ControlPhoneAnswer>()
       .AsSingle();

        Container.BindInterfacesAndSelfTo<ControlPresentEvent>()
       .AsSingle();

        Container.BindInterfacesAndSelfTo<ControlHistoryEvent>()
       .AsSingle();
    }

    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<ImporterCounterSlotHistorySystem>()
      .AsSingle();
        
    }
}