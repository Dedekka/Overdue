using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UiInstaller : MonoInstaller
{
    [SerializeField] private AudioSettings _audioSettings;
    [SerializeField] private List<SelectUiSoundButton> _selectUiSoundButton;
    [SerializeField] private List<SimpleSlider> _selectUiSoundSlider;

    public override void InstallBindings()
    {
        BindUI();
    }

    private void BindUI()
    {

        Container.BindInterfacesAndSelfTo<ControlUiSound>()
        .AsSingle()
        .WithArguments(_selectUiSoundButton, _selectUiSoundSlider);

        Container.Bind<AudioUi>()
        .AsSingle()
        .WithArguments(_audioSettings);

       
    }
}

[Serializable]
public class SelectUiSoundButton
{
    public SimpleButton Selectable;
    public SoundUi SoundUi;
}

public enum SoundUi
{
    LoadScene,
    Click
}

