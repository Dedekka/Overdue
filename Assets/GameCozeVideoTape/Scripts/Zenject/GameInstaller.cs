using SaveLoadSystem;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Header("PauseMenu")]
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private PlayerUi _playerUi;
    [SerializeField] private Transform _hand;
    [Header("DataCassets")]
    private DataCassets _dataCassets;
    private DataLanguage _dataLanguage;
    [Header("Materials")]
    [SerializeField] private Material _cassetteMaterial;
    [SerializeField] private Material _presentMaterial;
    [Header("Items")]
    [SerializeField] private PickUpSettings _pickUpSettings;
    [SerializeField] private ShelfSlotSettings _shelfSlotSettings;
    [SerializeField] private float _timeWaitCheckPhysics;
    [Header("ItemsDecor")]
    [SerializeField] private Material _decorMaterial;
    [SerializeField] private Material _slotMaterial;
    [Header("Rack")]
    [SerializeField] private int _maxRack;
    [SerializeField] private int _maxCassette;
    [Header("Phone")]
    [SerializeField] private Phone _phone;
    [Header("EventRealizer")]
    [SerializeField] private PackageSystem _packageSystem;
    [SerializeField] private Present _prefabPresent;
    [SerializeField] private Transform _returnedPosition;
    private DataPresent _presentData;


    public override void InstallBindings()
    {
        FindSub();
        BindUI();
        BindItem();
        BindSystem();
        BindSaveSystem();
        BindImporter();
        BindRack();
        BindPauseSystem();
        BindPhone();
        BindEventRealizer();
        BindPresentDecor();

    }

    private void BindEventRealizer()
    {
        Container.Bind<RealizerReturned>()
         .AsSingle();

        Container.Bind<RealizerPresent>()
        .AsSingle();

        Container.Bind<PresentSpawner>()
        .AsSingle();

        Container.Bind<PackageSystem>()
         .FromInstance(_packageSystem)
           .AsSingle();

        Container.Bind<FactoryPresent>()
        .AsSingle()
        .WithArguments(_prefabPresent, _presentData, _presentMaterial);

        Container.Bind<ReturnedMover>()
        .AsSingle()
        .WithArguments(_returnedPosition);
    }

    private void BindPresentDecor()
    {
        Container.Bind<DecorChecker>()
           .AsSingle();

        Container.Bind<Material>()
            .WithId("SlotMaterial")
            .FromInstance(_slotMaterial)
            .AsCached();

        Container.Bind<Material>()
            .WithId("DecorMaterial")
            .FromInstance(_decorMaterial)
            .AsCached();



        //Container.Bind<DecorRender>()
        //   .AsTransient()
        //   .WithArguments(_slotMaterial, _decorMaterial);
    }

    private void BindPhone()
    {
        Container.Bind<Phone>()
           .FromInstance(_phone)
           .AsSingle();
    }

    private void FindSub()
    {
        _dataCassets = Resources.Load<DataCassets>(PathConst.DataCassetsAsset);
        _dataLanguage = Resources.Load<DataLanguage>(PathConst.LanguageCassetsAsset);
        _presentData = Resources.Load<DataPresent>(PathConst.DataPresentAsset);
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

        Container.Bind<ViewRenderer>()
          .AsSingle();

        Container.Bind<CassetteRenderer>()
          .AsSingle()
          .WithArguments(_cassetteMaterial);

        Container.Bind<ShelfSlotSettings>()
          .FromInstance(_shelfSlotSettings)
          .AsSingle();


    }

    private void BindSystem()
    {
        Container.BindInterfacesAndSelfTo<ManagerCassette>()
           .AsSingle()
           .WithArguments(_dataCassets, _maxCassette);//, _dataLanguage);

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

    private void BindPauseSystem()
    {
        Container.Bind<PauseSystem>()
         .AsSingle()
          .WithArguments(_pauseMenu);

    }

    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<SaveInventoryImporter>()
         .AsSingle();

        Container.BindInterfacesAndSelfTo<PauseSystemPlayerStateImporter>()
         .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterImporterDialogSystem>()
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