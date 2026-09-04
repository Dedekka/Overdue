using System;
using UnityEngine.UI;
using Zenject;

public class ImporterSliderSoundSystem : IDisposable, IInitializable
{
    private SoundSystem _soundSystem;
    private Slider _sliderMain;
    private Slider _sliderEffects;
    private Slider _sliderVoice;
    private Slider _sliderMusic;

    public ImporterSliderSoundSystem(Slider sliderMain, Slider sliderEffects, Slider sliderVoice, Slider sliderMusic, SoundSystem soundSystem)
    {
        _sliderMain = sliderMain;
        _sliderEffects = sliderEffects;
        _sliderVoice = sliderVoice;
        _sliderMusic = sliderMusic;
        _soundSystem = soundSystem;
    }

    public void Initialize()
    {
        _sliderMain.onValueChanged.AddListener(_soundSystem.SetMainVolume);
        _sliderEffects.onValueChanged.AddListener(_soundSystem.SetEffectsVolume);
        _sliderVoice.onValueChanged.AddListener(_soundSystem.SetVoiceVolume);
        _sliderMusic.onValueChanged.AddListener(_soundSystem.SetMusicVolume);
        _soundSystem.OnLoadSoundSystem += UpdateSliderVolume;
    }

    public void Dispose()
    {
        _soundSystem.OnLoadSoundSystem -= UpdateSliderVolume;
    }

    private void UpdateSliderVolume()
    {
        _sliderMain.value = _soundSystem.GetVolume(TypeVolume.Main);
        _sliderEffects.value = _soundSystem.GetVolume(TypeVolume.Effects);
        _sliderVoice.value = _soundSystem.GetVolume(TypeVolume.Voice);
        _sliderMusic.value = _soundSystem.GetVolume(TypeVolume.Music);
    }
}