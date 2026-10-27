using System;
using UnityEngine;

public class CatAnimation 
{
    private Animator _animator;
    private ParticleSystem _catHeartParticle;
    private int InteractionAnimationID;

    public CatAnimation(ParticleSystem catHeartParticle)
    {
        _catHeartParticle = catHeartParticle;
    }

    public void Initialization(Animator animator)
    {
        _animator = animator;
        InteractionAnimationID = Animator.StringToHash("Interaction");
    }

    public void TryActive()
    {
        _animator.SetTrigger(InteractionAnimationID);
    }

    public void OnHeartEvent()
    {
        _catHeartParticle.Play();
    }
}