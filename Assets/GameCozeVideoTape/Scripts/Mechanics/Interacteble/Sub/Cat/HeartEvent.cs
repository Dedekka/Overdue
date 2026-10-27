using System;
using UnityEngine;

public class HeartEvent : MonoBehaviour
{
    public event Action OnHeartEvent;

    public void Heart()
    {
        OnHeartEvent?.Invoke();
    }
}