using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ControlUiSound : IDisposable, IInitializable
{
    private List<SelectUiSoundButton> _selectUiSound;
    private List<SimpleSlider> _sliders;
    private AudioUi _audioUi;

    public ControlUiSound(List<SelectUiSoundButton> selectUiSound, List<SimpleSlider> sliders, AudioUi audioUi)
    {
        _selectUiSound = selectUiSound;
        _sliders = sliders;
        _audioUi = audioUi;
    }

    public void Initialize()
    {
        FindUiSound();
    }

    public void Dispose()
    {
        UnSub();
    }

    private void FindUiSound()
    {
        SubSound(_selectUiSound);
        SubSound(_sliders);
    }

    private void SubSound(List<SelectUiSoundButton> selectUiSoundButtons)
    {
        SelectUiSoundButton selectUiSoundButton;
        for (int i = 0; i < selectUiSoundButtons.Count; i++)
        {
            selectUiSoundButton = selectUiSoundButtons[i];
            _audioUi.SubSound(selectUiSoundButton);
        }
    }

    private void SubSound(List<SimpleSlider> sliders)
    {
        SimpleSlider slider;
        for (int i = 0; i < sliders.Count; i++)
        {
            slider = sliders[i];
            _audioUi.SubSound(slider);
        }
    }

    private void UnSub()
    {
        for (int i = 0; i < _sliders.Count; i++)
        {
            _sliders[i].onValueChanged.RemoveAllListeners();
        }

        for (int i = 0; i < _selectUiSound.Count; i++)
        {
            _selectUiSound[i].Selectable.onClick.RemoveAllListeners();
            _selectUiSound[i].Selectable.Disable();
        }
    }
}
