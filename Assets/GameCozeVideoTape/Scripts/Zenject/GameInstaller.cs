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
        BindPickUp();
    }

    private void BindUI()
    {
        Container.Bind<PlayerUi>()
           .FromInstance(_playerUi)
           .AsSingle()
           .NonLazy();
    }

    private void BindPickUp()
    {
        Container.Bind<PickUpItem>()
            .AsTransient()
            .WithArguments(_pickUpSettings, _hand);
    }
}