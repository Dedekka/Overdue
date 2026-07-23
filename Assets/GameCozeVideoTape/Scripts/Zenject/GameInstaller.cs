using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PlayerUi _playerUi;
    [SerializeField] private PickUpSettings _pickUpSettings;
    [SerializeField] private Transform _hand;
    [Header("DataCassets")]
    private DataCassets _dataCassets;
    private DataLanguage _dataLanguage;

    public override void InstallBindings()
    {
        FindSub();
        BindUI();
        BindItem();
        BindSystem();
    }

    private void FindSub()
    {
        _dataCassets = Resources.Load<DataCassets>(Path.DataCassetsAsset);
        _dataLanguage = Resources.Load<DataLanguage>(Path.LanguageCassetsAsset);
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

        Container.Bind<CassetteRenderer>()
          .AsSingle();
    }

    private void BindSystem()
    {
        Container.Bind<ManagerCassette>()
           .AsSingle()
           .WithArguments(_dataCassets, _dataLanguage);

    }
}