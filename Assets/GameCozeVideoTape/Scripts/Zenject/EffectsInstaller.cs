using System;
using UnityEngine;
using Zenject;

public class EffectsInstaller : MonoInstaller
{
    [SerializeField] private EffectSettings _effectSettings;

    public override void InstallBindings()
    {
        BindEffects();
        BindGarland();
    }


    private void BindEffects()
    {
        Container.Bind<EffectSettings>()
        .FromInstance(_effectSettings)
        .AsSingle();

        Container.Bind<CassetteEffects>()
        .AsTransient();

        Container.Bind<ControlCassetteEffects>()
        .AsTransient();
    }

    private void BindGarland()
    {
        Container.Bind<GarlandRender>()
       .AsSingle();
    }

}