using System;
using Zenject;

public class AudioCassetteImporter
{
  
    private AudioManager _audioManager;

    public AudioCassetteImporter(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public void SubCassette(CassetteObject cassetteObject)
    {
        cassetteObject.OnPickUp += PlayPickUp;
        cassetteObject.OnDrop += PlayDrop;
    }

    public void UnSubCassette(CassetteObject cassetteObject)
    {
        cassetteObject.OnPickUp -= PlayPickUp;
        cassetteObject.OnDrop -= PlayDrop;
    }

    private void PlayPickUp(CassetteObject cassetteObject)
    {
        _audioManager.PlayPickUp();
    }

    private void PlayDrop()
    {
        _audioManager.PlayDrop();
    }

}
