using System;
using Zenject;

public class HistoryInstaller : MonoInstaller
{
    //[SerializeField] private EventOne _eventOne;
    //[SerializeField] private EventTwo _eventTwo;

    public override void InstallBindings()
    {
        // Container.Bind<EventOne>()
        //.FromInstance(_eventOne)
        //.AsSingle();

        // Container.Bind<EventTwo>()
        //.FromInstance(_eventTwo)
        //.AsSingle();
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