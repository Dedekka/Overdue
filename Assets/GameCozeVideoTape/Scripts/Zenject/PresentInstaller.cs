using UnityEngine;
using Zenject;

public class PresentInstaller : MonoInstaller
{
    [SerializeField] private Transform _soundDoorPoint;

    public override void InstallBindings()
    {
        BindPresent();
    }

    private void BindPresent()
    {
        Container.Bind<PresentSound>()
          .AsSingle()
          .WithArguments(_soundDoorPoint);

        Container.Bind<PresentEffect>()
          .AsSingle();
    }
}