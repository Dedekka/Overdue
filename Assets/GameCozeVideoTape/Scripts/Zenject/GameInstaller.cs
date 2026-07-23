using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PlayerUi _playerUi;
    [SerializeField] private PickUpSettings _pickUpSettings;
    [SerializeField] private Transform _hand;
    [Header("DataCassets")]
    [SerializeField] private DataCassets _dataCassets;
    [SerializeField] private DataLanguage _dataLanguage;

    public override void InstallBindings()
    {
        BindUI();
        BindItem();
        BindSystem();
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