using FMOD.Studio;
using System;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

public class SoundSystem : IInitializable
{

    private readonly string _mainBusPath;
    private readonly string _effectsBusPath;
    private readonly string _voiceBusPath;
    private readonly string _musicBusPath;

    private Bus _mainBus;
    private Bus _effectsBus;
    private Bus _voiceBus;
    private Bus _musicBus;

    public event Action OnLoadSoundSystem;

    public SoundSystem(SettingsSound settingsSound)
    {
        _mainBusPath = settingsSound.MainBusPath;
        _effectsBusPath = settingsSound.EffectsBusPath;
        _voiceBusPath = settingsSound.VoiceBusPath;
        _musicBusPath = settingsSound.MusicBusPath;
    }

    public void Initialize()
    {
        Initialization();
    }

    public void SetMainVolume(float Volume)
    {
        ChangeValue(_mainBus, Volume);
    }

    public void SetEffectsVolume(float Volume)
    {
        ChangeValue(_effectsBus, Volume);
    }

    public void SetVoiceVolume(float Volume)
    {
        ChangeValue(_voiceBus, Volume);
    }

    public void SetMusicVolume(float Volume)
    {
        ChangeValue(_musicBus, Volume);
    }

    public float GetVolume(TypeVolume typeVolume)
    {
        float volume = 0.0f;
        switch (typeVolume)
        {
            case TypeVolume.Main:
                _mainBus.getVolume(out volume);
                break;
            case TypeVolume.Effects:
                _effectsBus.getVolume(out volume);
                break;
            case TypeVolume.Voice:
                _voiceBus.getVolume(out volume);
                break;
            case TypeVolume.Music:
                _musicBus.getVolume(out volume);
                break;
            default:
                break;
        }
        return volume;
    }

  

    private void Initialization()
    {
        SetBus(ref _mainBus, _mainBusPath);
        SetBus(ref _effectsBus, _effectsBusPath);
        SetBus(ref _voiceBus, _voiceBusPath);
        SetBus(ref _musicBus, _musicBusPath);
        OnLoadSoundSystem?.Invoke();
    }

    private void ChangeValue(Bus bus, float Volume)
    {
        //if (textValue != null && slider != null) 
        //{
        //    float tempValue = slider.value * 100f;
        //textValue.SetText(tempValue.ToString("000"));
        //    bus.setVolume(slider.value / slider.maxValue); 
        //}
        bus.getPath(out string path);

        Debug.Log($"Bus_Path:{path}, Volume:{Volume} ");
        bus.setVolume(Volume);
    }

    private void SetBus(ref Bus bus, string busPath)
    {
        if (busPath != "")
        {
            bus = FMODUnity.RuntimeManager.GetBus(busPath);
        }
        else
        {
            Debug.LogError("busPath = Null");
        }
    }
}

public enum TypeVolume
{
    Main,
    Effects,
    Voice,
    Music
}