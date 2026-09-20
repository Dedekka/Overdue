using UnityEngine;

public class PresentSound 
{
    private Transform _pointDoor;
    private AudioManager _audioManager;

    public PresentSound(Transform pointDoor, AudioManager audioManager)
    {
        _pointDoor = pointDoor;
        _audioManager = audioManager;
    }

    public void ActivationPresentSound()
    {
        _audioManager.PlayDoor(_pointDoor.position);
    }
}
