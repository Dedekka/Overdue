using UnityEngine;
using Zenject;

public class HistoryInstaller : MonoInstaller
{
    [SerializeField] private EventOne _eventOne;
    [SerializeField] private EventTwo _eventTwo;

    public override void InstallBindings()
    {
        Container.Bind<EventOne>()
       .FromInstance(_eventOne)
       .AsSingle();

        Container.Bind<EventTwo>()
       .FromInstance(_eventTwo)
       .AsSingle();

        Container.Bind<HistorySystem>()
       .AsSingle();

    }
}