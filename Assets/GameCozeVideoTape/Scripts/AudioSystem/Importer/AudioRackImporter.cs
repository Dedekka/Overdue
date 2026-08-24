using UnityEngine;

public class AudioRackImporter 
{
    private AudioManager _audioManager;

    public AudioRackImporter(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public void SubCassette(Rack rack)
    {
        rack.OnInstallState += OnInstallState;
    }

    public void UnSubCassette(Rack rack)
    {
        rack.OnInstallState -= OnInstallState;
    }

    private void OnInstallState(bool State)
    {
        if (State)
        {
            _audioManager.PlaySnapCorrect();
        }
        else
        {
            _audioManager.PlaySnapWrong();

        }
    }
}
