using UnityEngine;
using Zenject;

public class EffectsInstaller : MonoInstaller
{
    [SerializeField] private EffectSettings _effectSettings;

    public override void InstallBindings()
    {
        BindEffects();
    }



    private void BindEffects()
    {
        Container.Bind<EffectSettings>()
        .FromInstance(_effectSettings)
        .AsSingle();

        Container.Bind<CassetteEffects>()
        .AsTransient();
    }
}