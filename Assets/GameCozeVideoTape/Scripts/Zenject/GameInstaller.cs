using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PlayerUi _playerUi;
    [SerializeField] private PickUpSettings _pickUpSettings;
    [SerializeField] private Transform _hand;

    public override void InstallBindings()
    {
        BindUI();
        BindItem();
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
}