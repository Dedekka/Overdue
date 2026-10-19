using UnityEngine;

public class DecorEffect
{
    private ParticleSystem _decorInstallParticle;

    public DecorEffect(ParticleSystem decorInstall)
    {
        _decorInstallParticle = decorInstall;
    }


    public void SetPosition(Transform Position)
    {
        _decorInstallParticle.transform.position = Position.position;
    }

    public void ActiveEffect()
    {
        _decorInstallParticle.Play();
    }
}