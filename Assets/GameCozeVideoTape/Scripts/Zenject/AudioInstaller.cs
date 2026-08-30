using FMODUnity;
using System;
using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [SerializeField] private AudioSettings _audioSettings;
    [SerializeField] private int _maxAudioItem;
    [SerializeField] private Material _materialAudioItem;
    [Header("AudioRecorderAnimation")]
    [SerializeField] private Transform _buttonPlay;
    [SerializeField] private Transform _coverPlate;
    [SerializeField] private Transform _recorderSlotPosition;
    [SerializeField] private Transform _preRecorderSlotPosition;


    public override void InstallBindings()
    {
        FindSub();
        BindSystem();
        BindImporter();
        BindEmitter();
        BindAudioCassettsSystem();
    }

    private void BindAudioCassettsSystem()
    {
        Container.BindInterfacesAndSelfTo<AudioCassettsSystem>()
         .AsSingle();

        Container.Bind<AudioCassetteAnimation>()
         .AsSingle()
         .WithArguments(_recorderSlotPosition, _preRecorderSlotPosition);

        Container.Bind<ManagerAudioItem>()
         .AsSingle()
         .WithArguments(_maxAudioItem);

        Container.Bind<AudioItemRenderer>()
         .AsSingle()
         .WithArguments(_materialAudioItem);

        Container.BindInterfacesAndSelfTo<AudioRecorderAnimation>()
         .AsSingle()
         .WithArguments(_buttonPlay, _coverPlate);
    }

    private void FindSub()
    {
        Container.Bind<DataMusicCassets>()
          .FromResource(PathConst.DataMusicCassetsAsset)
          .AsSingle();
    }

    private void BindEmitter()
    {
        Container.Bind<AudioCassette>()
         .AsSingle();

        Container.Bind<AudioRack>()
         .AsSingle();

        Container.Bind<MusicControl>()
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

        Container.BindInterfacesAndSelfTo<ImporterMusicControlAudio>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterRecorderAnimationMusicControl>()
            .AsSingle();
    }

    private void BindSystem()
    {
        Container.BindInterfacesAndSelfTo<AudioManager>()
           .AsSingle()
           .WithArguments(_audioSettings);
    }
}
