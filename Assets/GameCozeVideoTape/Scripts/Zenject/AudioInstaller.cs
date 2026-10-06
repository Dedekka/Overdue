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

    [Header("PositionEvent")]
    [SerializeField] private Transform _soundDoorPoint;
    [SerializeField] private Transform _soundPhonePoint;
    [SerializeField] private Transform _soundAmbientOutsidePoint;
    [SerializeField] private Transform _soundRecorderPoint;
    [SerializeField] private Transform _soundTvPoint;

    public override void InstallBindings()
    {
        FindSub();
        BindSystem();
        BindImporter();
        BindPositionEvent();
        BindEmitter();
        BindPlayerSaySystem();
        BindAudioCassettsSystem();
    }



    private void BindPlayerSaySystem()
    {
        Container.BindInterfacesAndSelfTo<PlayerSaySystem>()
         .AsSingle();

        Container.Bind<FactorySayEvent>()
         .AsSingle();
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

        Container.Bind<ControlMusicLanguage>()
         .AsSingle();

        Container.Bind<ControlDialogLanguage>()
         .AsSingle();
    }

    private void FindSub()
    {
        Container.Bind<DataMusicCassets>()
          .FromResource(PathConst.DataMusicCassetsAsset)
          .AsSingle();

        Container.Bind<DataMusicLanguage>()
          .FromResource(PathConst.DataMusicLanguageAsset)
          .AsSingle();
    }

    private void BindPositionEvent()
    {
        Container.Bind<PresentSound>()
        .AsSingle()
        .WithArguments(_soundDoorPoint);

        Container.Bind<PhoneSound>()
          .AsSingle()
          .WithArguments(_soundPhonePoint);
    }

    private void BindEmitter()
    {
        Container.Bind<TvGanreSound>()
         .AsSingle();

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

        Container.BindInterfacesAndSelfTo<ImporterTVAudioManager>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterInventoryPresentAudioManager>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterRecorderAnimationMusicControl>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterInventoryCassetteAudioManager>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterDialogSystemCallAudioManager>()
            .AsSingle();
    }

    private void BindSystem()
    {
        Container.BindInterfacesAndSelfTo<AudioManager>()
           .AsSingle()
           .WithArguments(_audioSettings, new GroupEmitter()
           {
               //AmbientOutsideEmitter = _ambientOutsideEmitter,
               SoundTvPoint = _soundTvPoint,
               SoundRecorderPoint = _soundRecorderPoint,
               //DoorEmitter = _doorEmitter,
               //PhoneEmitter = _phoneEmitter,
           });
    }
}

public class GroupEmitter
{
    //public Transform PhoneEmitter;
    //public StudioEventEmitter DoorEmitter;
    public Transform SoundRecorderPoint;
    public Transform SoundTvPoint;
    //public StudioEventEmitter AmbientOutsideEmitter;
}

