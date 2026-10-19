using UnityEngine;

public class PresentEffect
{
    private ParticleSystem _present;
    private ParticleSystem _returned;
    private PresentSound _presentSound;
    private PresentEvent _presentEvent;
    public PresentEffect(PresentSound presentSound, ParticleSystem present, ParticleSystem returned)
    {
        _presentSound = presentSound;
        _present = present;
        _returned = returned;
    }

    public void SetCallData(PresentEvent presentEvent)
    {
        _presentEvent = presentEvent;
    }

    public void ActivationPresentEffect()
    {
        _presentSound.ActivationPresentSound();
        CheckActiveEffect();
    }

    private void CheckActiveEffect()
    {
        if (_presentEvent.IDCassette>0)
        {
            _returned.Play();
        }

        if (_presentEvent.IDPresent>0)
        {
            _present.Play();
        }
    }
}