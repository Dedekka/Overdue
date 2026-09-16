using Unity.Cinemachine;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [Header("Continue")]
    [SerializeField] private Player _playerCharecter;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _groundPoint;

    [Header("PlayerLook/PlayerInteracteble")]
    [SerializeField] private Transform _headSlot;

    [Header("PlayerAim")]
    [SerializeField] private CinemachineCamera cinemachineCamera;

    [Header("PlayerInventory")]
    [SerializeField] private Transform _handSlot;
    [SerializeField] private Transform[] _inventorySlot;
    [SerializeField] private Transform _slotItem_0;

    [Header("PlayerSmoothLogic")]
    [SerializeField] private Transform _bodyLogic;

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
            .WithArguments( _characterController, _groundPoint)
            .NonLazy();

        Container.Bind<PlayerLook>()
            .AsSingle()
            .WithArguments( _headSlot, _playerCharecter.transform)
            .NonLazy();

        Container.BindInterfacesAndSelfTo<PlayerInteracteble>()
            .AsSingle()
            .WithArguments( _headSlot)
            .NonLazy();

        Container.BindInterfacesAndSelfTo<PlayerAim>()
            .AsSingle()
            .WithArguments( cinemachineCamera)
            .NonLazy();

        Container.BindInterfacesAndSelfTo<PlayerInventory>()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<PlayerSmoothLogic>()
            .AsSingle()
            .WithArguments( _bodyLogic);

        Container.Bind<InventoryCassette>()
            .AsSingle()
            .WithArguments( _handSlot, _inventorySlot);

        Container.Bind<InventoryPresent>()
            .AsSingle()
            .WithArguments( _slotItem_0);

        Container.BindInterfacesAndSelfTo<PlayerStateControl>()
           .AsSingle();
    }

    private void BindInput()
    {
        Container.BindInterfacesAndSelfTo<PlayerInputControl>()
           .AsSingle()
           .NonLazy();

        Container.Bind<EventInputSystem>()
           .AsSingle();

        Container.Bind<PlayerSystemActions>()
           .AsSingle()
           .NonLazy();
    }

    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<ImporterAimMove>()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<ImporterAimSensitivity>()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<ImporterMainLookSensitivity>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterPlayerStatePlayerInput>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterPlayerStateDialogSystem>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterPresentPlayerInventory>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterPlayerUiTvManager>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterTvManagerPlayer>()
            .AsSingle();
    }

    private void BindUI()
    {
        Container.BindInterfacesAndSelfTo<ImporterInteractebleUI>()
           .AsSingle()
           .NonLazy();

        Container.BindInterfacesAndSelfTo<ImporterInventoryUI>()
         .AsSingle()
         .NonLazy();

        Container.BindInterfacesAndSelfTo<ImporterPhonePlayerStateControl>()
       .AsSingle();
    }
}