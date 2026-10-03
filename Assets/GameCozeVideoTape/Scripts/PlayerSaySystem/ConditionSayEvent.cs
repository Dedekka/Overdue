using System;
using UnityEngine;

public abstract class ConditionSayEvent 
{
    public event Action<ConditionSayEvent> OnComplited;

    public virtual void Initialization(){}

    protected void Complited()
    {
        OnComplited?.Invoke(this);
    }
}