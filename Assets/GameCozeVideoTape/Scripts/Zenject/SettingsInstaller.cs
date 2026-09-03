using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SettingsInstaller : MonoInstaller
{
    //[Header("Buttons")]
    //[SerializeField] private Button _buttonNewGame;
    //[SerializeField] private Button _buttonExit;
    [Header("Sliders sound")]
    [SerializeField] private Slider _sliderMain;
    [SerializeField] private Slider _sliderEffects;
    [SerializeField] private Slider _sliderVoice;
    [SerializeField] private Slider _sliderMusic;
    [Header("Sliders sensitivity")]
    [SerializeField] private Slider _sliderSensitivity;
    [Header("DropDown Language")]
    [SerializeField] private TMP_Dropdown _dropDownLanguage;

    
    public override void InstallBindings()
    {
        BindSub();
        BindControlLogic();
        BindSound();
        BindSensitivity();
        BindLanguage();
    }

    private void BindSub()
    {
        Container.BindInterfacesAndSelfTo<ImporterSliderSoundSystem>()
          .AsSingle()
          .WithArguments(_sliderMain, _sliderEffects, _sliderVoice, _sliderMusic);

    }

    private void BindControlLogic()
    {
        Container.Bind<ControlLogic>()
            .AsSingle();

        Container.Bind<ControlSound>()
            .AsSingle();

        Container.Bind<LoadingSystem>()
            .AsSingle();
    }

    private void BindSound()
    {
        Container.BindInterfacesAndSelfTo<SoundSystem>()
            .AsSingle();
    }

    private void BindSensitivity()
    {

    }

    private void BindLanguage()
    {

    }
}