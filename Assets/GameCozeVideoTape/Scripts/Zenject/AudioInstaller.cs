using FMODUnity;
using System;
using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [SerializeField] private AudioSettings _audioSettings;

    public override void InstallBindings()
    {
        BindSystem();
        BindImporter();
        BindEmitter();
    }

    private void BindEmitter()
    {
        Container.Bind<AudioCassette>()
         .AsSingle();

        Container.Bind<AudioRack>()
         .AsSingle();
    }

    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<AudioCassetteImporter>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<AudioRackImporter>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<AudioPauseSystemImporter>()
            .AsSingle();
    }

    private void BindSystem()
    {
        Container.BindInterfacesAndSelfTo<AudioManager>()
           .AsSingle()
           .WithArguments(_audioSettings);
    }
}
