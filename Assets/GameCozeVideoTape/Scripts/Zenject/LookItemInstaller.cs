using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

public class LookItemInstaller : MonoInstaller
{
    [SerializeField] private SettingsLookItem _settingsLookItem;
    [SerializeField] private CinemachineCamera _itemCamera;
    [SerializeField] private LookItemUi _lookItemUi;
    [SerializeField] private Transform _lookItemSlot;
    [SerializeField] private Volume _lookItemEffects;

    public override void InstallBindings()
    {
        BindLookItem();
        BindLookItemControl();
        BindUi();
        BindImporter();
    }

    private void BindLookItem()
    {
        Container.Bind<SettingsLookItem>()
            .FromInstance(_settingsLookItem)
            .AsSingle();

        Container.Bind<PlayerLookItem>()
            .AsSingle();
    }

    private void BindLookItemControl()
    {
        Container.Bind<LookItemMove>()
            .AsSingle()
            .WithArguments(_lookItemSlot);
        
        Container.Bind<LookItemRotate>()
            .AsSingle()
            .WithArguments(_lookItemSlot);

        Container.Bind<LookItemCamera>()
            .AsSingle()
            .WithArguments(_itemCamera);
        
        Container.Bind<LookItemControlUi>()
            .AsSingle();
        
        Container.Bind<LookItemEffects>()
            .AsSingle()
            .WithArguments(_lookItemEffects);
    }

    private void BindUi()
    {
        Container.Bind<LookItemUi>()
           .FromInstance(_lookItemUi)
           .AsSingle();
    }

    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<ImporterPlayerLookItemState>()
        .AsSingle();
    }
}