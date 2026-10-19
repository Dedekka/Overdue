using UnityEngine;
using Zenject;

public class EffectsInstaller : MonoInstaller
{
    [SerializeField] private EffectSettings _effectSettings;

    [Header("AudioRecorderAnimation")]

    [SerializeField] private Transform _buttonPlay;
    [SerializeField] private Transform _coverPlate;

    [Header("Effects")]
    [SerializeField] private ParticleSystem _phoneRingParticle;
    [SerializeField] private ParticleSystem _presentSpawnParticle;
    [SerializeField] private ParticleSystem _returnedParticle;
    [SerializeField] private ParticleSystem _decorInstallParticle;
    [SerializeField] private ParticleSystem _musicPlayngParticle;

    public override void InstallBindings()
    {
        BindEffects();
        BindGarland();
        BindPhone();
        BindPresent();
        BindAudioRecorder();
    }

    private void BindAudioRecorder()
    {
        Container.BindInterfacesAndSelfTo<AudioRecorderAnimation>()
       .AsSingle()
       .WithArguments(_buttonPlay, _coverPlate, _musicPlayngParticle);
    }

    private void BindPhone()
    {
        Container.Bind<PhoneEffect>()
          .AsSingle()
          .WithArguments(_phoneRingParticle);
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

    private void BindPresent()
    {
        Container.Bind<PresentEffect>()
        .AsSingle()
        .WithArguments(_presentSpawnParticle, _returnedParticle);

        Container.Bind<DecorEffect>()
        .AsSingle()
        .WithArguments(_decorInstallParticle);
    }

}