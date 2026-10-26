using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SimpleSlider : Slider
{
    public event Action OnEnter;
    private bool isEnter;

    public void Disable()
    {
        OnEnter = null;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        OnEnter?.Invoke();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        isEnter = false;
        base.OnPointerExit(eventData);
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        if (!isEnter)
        {
            OnEnter?.Invoke();
        }
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        isEnter = false;
    }
}