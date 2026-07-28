using SaveLoadSystem;
using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PlayerUi _playerUi;
    [SerializeField] private Transform _hand;
    [Header("DataCassets")]
    private DataCassets _dataCassets;
    private DataLanguage _dataLanguage;
    [Header("Materials")]
    [SerializeField] private Material _material;
    [Header("Items")]
    [SerializeField] private PickUpSettings _pickUpSettings;
    [SerializeField] private ShelfSlotSettings _shelfSlotSettings;
    [SerializeField] private float _timeWaitCheckPhysics;
    [Header("Rack")]
    [SerializeField] private int _maxRack;

    public override void InstallBindings()
    {
        FindSub();
        BindUI();
        BindItem();
        BindSystem();
        BindSaveSystem();
        BindImporter();
        BindRack();
    }

   

    private void FindSub()
    {
        _dataCassets = Resources.Load<DataCassets>(PathConst.DataCassetsAsset);
        _dataLanguage = Resources.Load<DataLanguage>(PathConst.LanguageCassetsAsset);
    }

    private void BindUI()
    {
        Container.Bind<PlayerUi>()
           .FromInstance(_playerUi)
           .AsSingle()
           .NonLazy();
    }

    private void BindItem()
    {
        Container.Bind<PickUpItem>()
            .AsTransient()
            .WithArguments(_pickUpSettings, _hand);

        Container.Bind<InstallItem>()
           .AsTransient();

        Container.Bind<StateItem>()
           .AsTransient();

        Container.Bind<CassetteRenderer>()
          .AsSingle()
          .WithArguments(_material);

        Container.Bind<ShelfSlotSettings>()
          .FromInstance(_shelfSlotSettings)
          .AsSingle();


    }

    private void BindSystem()
    {
        Container.BindInterfacesAndSelfTo<ManagerCassette>()
           .AsSingle()
           .WithArguments(_dataCassets);//, _dataLanguage);

        Container.BindInterfacesAndSelfTo<ControlSleepCassette>()
          .AsSingle()
          .WithArguments(_timeWaitCheckPhysics);
    }

    private void BindSaveSystem()
    {
        Container.Bind<SaveLoadStrategy>()
          .AsSingle();

        Container.Bind<CassetteHolder>()
           .AsSingle();

        Container.BindInterfacesAndSelfTo<Saver>()
           .AsSingle();
    }

    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<SaveInventoryImporter>()
         .AsSingle();
    }

    private void BindRack()
    {
        Container.BindInterfacesAndSelfTo<ManagerRack>()
          .AsSingle()
          .WithArguments(_maxRack);

        Container.Bind<RackHolder>()
          .AsSingle();
    }
}