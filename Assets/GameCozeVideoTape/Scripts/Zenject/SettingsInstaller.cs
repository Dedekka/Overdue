using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SettingsInstaller : MonoInstaller
{
    [Header("Sliders sound")]
    [SerializeField] private Slider _sliderMain;
    [SerializeField] private Slider _sliderEffects;
    [SerializeField] private Slider _sliderVoice;
    [SerializeField] private Slider _sliderMusic;
    [Header("Sliders sensitivity")]
    [SerializeField] private Slider _sliderSensitivity;
    [Header("Language")]
    [SerializeField] private Button _buttonLanguageR;
    [SerializeField] private Button _buttonLanguageL;
    [SerializeField] private List<PageButton> _pageButtons;

    public override void InstallBindings()
    {
        BindSub();
        BindSound();
        BindLanguage();
        BindButton();
    }

    private void BindButton()
    {
        Container.Bind<SettingsButton>()
            .AsSingle()
            .WithArguments(_pageButtons);
    }

    private void BindSub()
    {
        Container.BindInterfacesAndSelfTo<ImporterSliderSoundSystem>()
          .AsSingle()
          .WithArguments(_sliderMain, _sliderEffects, _sliderVoice, _sliderMusic);

        Container.BindInterfacesAndSelfTo<ImporterSliderControlSensitivity>()
          .AsSingle()
          .WithArguments(_sliderSensitivity);

        Container.BindInterfacesAndSelfTo<ControlSensitivity>()
          .AsSingle();

        Container.BindInterfacesAndSelfTo<ControlPanelSettings>()
          .AsSingle();
    }

    private void BindSound()
    {
        Container.BindInterfacesAndSelfTo<SoundSystem>()
            .AsSingle();
    }

    private void BindLanguage()
    {
        Container.BindInterfacesAndSelfTo<ControlLanguage>()
         .AsSingle()
         .WithArguments(_buttonLanguageR, _buttonLanguageL);
    }
}

public class SettingsButton
{
    public readonly List<PageButton> PageButtons;

    public SettingsButton(List<PageButton> pageButtons)
    {
        PageButtons = pageButtons;
    }
}