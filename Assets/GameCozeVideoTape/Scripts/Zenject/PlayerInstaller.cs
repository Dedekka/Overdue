using Unity.Cinemachine;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [Header("Continue")]
    [SerializeField] private Player _playerCharecter;
    [SerializeField] private SettingsPlayer _settingsPlayer;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _groundPoint;

    [Header("PlayerLook/PlayerInteracteble")]
    [SerializeField] private Transform _headSlot;

    [Header("PlayerAim")]
    [SerializeField] private CinemachineCamera cinemachineCamera;

    [Header("PlayerInventory")]
    [SerializeField] private Transform _handSlot;

    public override void InstallBindings()
    {
        BindPlayer();
        BindInput();
        BindImporter();
        BindUI();
    }

    private void BindPlayer()
    {
        Container.Bind<Player>()
        .FromInstance(_playerCharecter)
        .AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerMove>()
            .AsSingle()
            .WithArguments(_settingsPlayer, _characterController, _groundPoint)
            .NonLazy();

        Container.Bind<PlayerLook>()
            .AsSingle()
            .WithArguments(_settingsPlayer, _headSlot, _playerCharecter.transform)
            .NonLazy();

        Container.BindInterfacesAndSelfTo<PlayerInteracteble>()
            .AsSingle()
            .WithArguments(_settingsPlayer, _headSlot)
            .NonLazy();

        Container.BindInterfacesAndSelfTo<PlayerAim>()
            .AsSingle()
            .WithArguments(_settingsPlayer, cinemachineCamera)
            .NonLazy();

        Container.BindInterfacesAndSelfTo<PlayerInventory>()
            .AsSingle()
            .NonLazy();

        Container.Bind<InventorySlot>()
            .AsSingle()
            .WithArguments(_settingsPlayer, _handSlot);
    }

    private void BindInput()
    {
        Container.BindInterfacesAndSelfTo<PlayerInputControl>()
           .AsSingle()
           .NonLazy();

        Container.Bind<PlayerSystemActions>()
           .AsSingle()
           .NonLazy();
    }

    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<ImporterAimMove>()
            .AsSingle()
            .WithArguments(_settingsPlayer)
            .NonLazy();

        Container.BindInterfacesAndSelfTo<ImporterAimSensitivity>()
            .AsSingle()
            .WithArguments(_settingsPlayer)
            .NonLazy();
    }

    private void BindUI()
    {
        Container.BindInterfacesAndSelfTo<ImporterInteractebleUI>()
           .AsSingle()
           .NonLazy();
    }
}