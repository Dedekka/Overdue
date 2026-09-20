public class PresentEffect
{
    private PresentSound _presentSound;

    public PresentEffect(PresentSound presentSound)
    {
        _presentSound = presentSound;
    }

    public void ActivationPresentEffect()
    {
        _presentSound.ActivationPresentSound();
    }
}