using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PlayerUi _playerUi;

    public override void InstallBindings()
    {
        BindUI();
    }

    private void BindUI()
    {
        Container.Bind<PlayerUi>()
           .FromInstance(_playerUi)
           .AsSingle()
           .NonLazy();
    }
}