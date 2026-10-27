using UnityEngine;
using Zenject;

public class CatInstaller : MonoInstaller
{
    [SerializeField] private Cat _cat;
    [SerializeField] private CatTrigger _catTrigger;

    public override void InstallBindings()
    {
        BindCat();
    }

    private void BindCat()
    {
        Container.Bind<Cat>()
       .FromInstance(_cat)
       .AsSingle();

        Container.Bind<CatTrigger>()
      .FromInstance(_catTrigger)
      .AsSingle();

        Container.Bind<CatSound>()
      .AsSingle();



    }
}