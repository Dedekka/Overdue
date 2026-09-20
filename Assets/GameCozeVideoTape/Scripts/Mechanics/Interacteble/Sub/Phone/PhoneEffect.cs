using System;
using UnityEngine;

public class PhoneEffect 
{
    
    private PhoneSound _phoneSound;
    private PhoneAnimation _phoneAnimation;

    public PhoneEffect(PhoneSound phoneSound, PhoneAnimation phoneAnimation)
    {
        _phoneSound = phoneSound;
        _phoneAnimation = phoneAnimation;
    }

    public void ActivationRingEffect()
    {
        _phoneSound.ActivationRingSound();
        _phoneAnimation.ActivationRingAnimation();
        Debug.Log("Phone, ActiveCallEffect");
       

    }

    public void DeactivationRingEffect()
    {
        _phoneSound.DeactivationRingSound();
        _phoneAnimation.DeactivationRingAnimation();
        _phoneAnimation.ActivationCallAnimation();

        Debug.Log("Phone, ActiveCallEffect");
        // Класс отвечающий за эфекты телефона 
        // Вкл эффекты

    }
}
