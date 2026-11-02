using UnityEngine;
using UnityEngine.Rendering;

public class LookItemEffects 
{
    private Volume _volume;

    public LookItemEffects(Volume volume)
    {
        _volume = volume;
    }

    public void ActiveEffects(bool isActive)
    {
        _volume.enabled = isActive;
    }
}