using FMODUnity;
using UnityEngine;

public class AudioUi //: IDisposable, IInitializable
{
    private EventReference _ui_Select;
    private EventReference _ui_LoadScene;
    private EventReference _ui_Slider;
    private EventReference _ui_Click;
    private float _timeWaitSliderSound;
    private float _timeWait;


    public AudioUi(AudioSettings audioSettings)
    {
        _ui_Select = audioSettings.Ui_Select;
        _ui_LoadScene = audioSettings.Ui_LoadScene;
        _ui_Slider = audioSettings.Ui_Slider;
        _ui_Click = audioSettings.Ui_Click;
        _timeWaitSliderSound = audioSettings.TimeWaitSliderSound;
        _timeWait = 0f;
    }



    public void SubSound(SelectUiSoundButton selectUiSoundButton)
    {
        FindSound(selectUiSoundButton);
    }

    public void SubSound(SimpleSlider Slider)
    {
        Slider.onValueChanged.AddListener((x) => PlaySoundSlider());
        Slider.OnEnter += PlaySoundSelect;
    }

    private void FindSound(SelectUiSoundButton selectUiSoundButton)
    {
        if (selectUiSoundButton.SoundUi == SoundUi.LoadScene)
        {
            selectUiSoundButton.Selectable.onClick.AddListener(() => PlaySoundLoadScene());
        }
        else if (selectUiSoundButton.SoundUi == SoundUi.Click)
        {
            selectUiSoundButton.Selectable.onClick.AddListener(() => PlaySoundClick());
        }

        selectUiSoundButton.Selectable.OnEnter += PlaySoundSelect;
    }

    private void PlaySoundSelect()
    {
        Debug.Log("PlaySoundSelect");
        SoundTimer(_ui_Select);
        //if (Time.unscaledTime > _timeWait)
        //{
        //    _timeWait = Time.time + _timeWaitSliderSound;
        //    Play(_ui_Select);
        //}
    }

    private void PlaySoundClick()
    {
        Play(_ui_Click);
    }

    private void PlaySoundLoadScene()
    {
        Play(_ui_LoadScene);
    }

    private void PlaySoundSlider()
    {
        SoundTimer(_ui_Slider);
        //if (Time.unscaledTime > _timeWait)
        //{
        //    _timeWait = Time.time + _timeWaitSliderSound;
        //    Play(_ui_Slider);
        //}
    }

    private void SoundTimer(EventReference eventReference)
    {
        if (Time.unscaledTime > _timeWait)
        {
            _timeWait = Time.unscaledTime + _timeWaitSliderSound;
            Play(eventReference);
        }
    }

    private void Play(EventReference eventReference)
    {
        if (!eventReference.IsNull)
        {
            RuntimeManager.PlayOneShot(eventReference);
        }
    }
}