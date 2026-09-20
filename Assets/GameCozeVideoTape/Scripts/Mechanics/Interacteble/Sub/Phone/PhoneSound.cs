using UnityEngine;

public class PhoneSound
{
    private Transform _pointPhone;
    private AudioManager _audioManager;

    public PhoneSound(Transform pointPhone, AudioManager audioManager)
    {
        _pointPhone = pointPhone;
        _audioManager = audioManager;
    }

    public void ActivationRingSound()
    {
        _audioManager.PlayRing(_pointPhone.position);
    }

    public void DeactivationRingSound()
    {
        _audioManager.StopRing();
    }
}
