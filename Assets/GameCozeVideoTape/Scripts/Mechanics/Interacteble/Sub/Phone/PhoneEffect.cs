using System;
using UnityEngine;

public class PhoneEffect 
{
    private ParticleSystem _phoneRing;
    private PhoneSound _phoneSound;
    private PhoneAnimation _phoneAnimation;
    public event Action<bool> OnRingEffect;

    public PhoneEffect(PhoneSound phoneSound, PhoneAnimation phoneAnimation, ParticleSystem phoneRing)
    {
        _phoneSound = phoneSound;
        _phoneAnimation = phoneAnimation;
        _phoneRing = phoneRing;
    }

    public void ActivationRingEffect()
    {
        _phoneSound.ActivationRingSound();
        _phoneAnimation.ActivationRingAnimation();
        Debug.Log("Phone, ActiveCallEffect");
        _phoneRing.Play();
        OnRingEffect?.Invoke(true);

    }

    public void DeactivationRingEffect()
    {
        _phoneRing.Stop();
        _phoneSound.DeactivationRingSound();
        _phoneAnimation.DeactivationRingAnimation();
        _phoneAnimation.ActivationCallAnimation();
        OnRingEffect?.Invoke(false);
        Debug.Log("Phone, ActiveCallEffect");
        // Класс отвечающий за эфекты телефона 
        // Вкл эффекты

    }
}
