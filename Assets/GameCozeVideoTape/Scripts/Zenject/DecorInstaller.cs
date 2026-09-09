using System;
using UnityEngine;
using Zenject;

public class DecorInstaller : MonoInstaller
{
    [SerializeField] private DecorPresentSystem _decorPresentSystem;

    public override void InstallBindings()
    {
        BindDecor();
        BindImporter();
    }

    private void BindDecor()
    {
        Container.Bind<DecorPresentSystem>()
         .FromInstance(_decorPresentSystem)
         .AsSingle();
    }

    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<ImporterInventoryPresentDecorPresentSystem>()
        .AsSingle();
    }
}