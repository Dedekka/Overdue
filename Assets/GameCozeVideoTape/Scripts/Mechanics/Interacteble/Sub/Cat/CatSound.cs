using UnityEngine;

public class CatSound
{
    private AudioManager _audioManager;
    public CatSound(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public void PlaySoundIdle()
    {
        _audioManager.PlayCatIdle();
    }

    public void PlaySoundMeow()
    {
        _audioManager.PlayCatMeow();
    }
}