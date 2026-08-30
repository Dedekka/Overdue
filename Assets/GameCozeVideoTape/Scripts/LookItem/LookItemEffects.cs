using UnityEngine;
using UnityEngine.Rendering;

public class LookItemEffects 
{
    private Volume _Volume;

    public LookItemEffects(Volume volume)
    {
        _Volume = volume;
    }

    public void ActiveEffects(bool isActive)
    {
        _Volume.enabled = isActive;
    }
}