using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SimpleButton : Button
{
    public event Action OnEnter;
    private bool isEnter;

    public void Disable()
    {
        OnEnter = null;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        isEnter = true;
        base.OnPointerEnter(eventData);
        Debug.Log("OnPointerEnter");
        OnEnter?.Invoke();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        isEnter = false;
        Debug.Log("OnPointerExit");
        base.OnPointerExit(eventData);
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        if (!isEnter)
        {
        OnEnter?.Invoke();
        }
        Debug.Log("OnSelect");
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        isEnter = false;
        Debug.Log("OnDeselect");
    }
}

