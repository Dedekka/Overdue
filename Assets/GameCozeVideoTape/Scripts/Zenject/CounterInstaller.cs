using System;
using TMPro;
using UnityEngine;
using Zenject;

public class CounterInstaller : MonoInstaller
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public override void InstallBindings()
    {
        BindCounter();
        BindCounterRack();
        BindImporter();
    }

    private void BindCounterRack()
    {
        Container.Bind<CounterRackSlot>()
       .AsSingle();
    }

    private void BindCounter()
    {
        //Container.Bind<CounterSlotCassetteSystem>()
        //.AsSingle();

        Container.Bind<CounterSlotCassetteUi>()
        .AsSingle()
        .WithArguments(_scoreText);

        Container.BindInterfacesAndSelfTo<CounterSlotCassette>()
        .AsSingle();

        Container.Bind<FinderFreeSlot>()
        .AsSingle();



    }

    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<ImporterCounterSlotCassetteUi>()
        .AsSingle();

    }
}