using System;
using UnityEngine;
using Zenject;

public class DecorSlot : BazeInteracteble
{
    [SerializeField] private DecorRender _decorRender;
    private bool _isActiveSlot = false;
    [Inject(Id = "SlotMaterial")] private Material _slotMaterial;
    [Inject(Id = "DecorMaterial")] private Material _decorMaterial;

    public event Action OnInteract;
    public event Action<bool> OnEnterCursor;

    private void Awake()
    {
        _decorRender.SetMaterial(_slotMaterial, _decorMaterial);
    }

    protected override void Interact()
    {
        OnInteract?.Invoke();
    }

    public void ActiveSlot()
    {
        // Decor Render - отображает финальное видение декора 
        //_item.SetActive(true);
        _decorRender.ActiveDecor();
        gameObject.SetActive(false);
        _isActiveSlot = true;
    }

    public void ControlVisible(bool isVisible)
    {
        // Decor Render - отображает зеленое место под модель
        if (_isActiveSlot) { return; }
        _decorRender.VisibleSlot(isVisible);
        _isShowPanelUse = isVisible;
        //_item.SetActive(isVisible);
    }

    public override void EnterCursor(bool isVisible)
    {
        if (_isActiveSlot) { return; }
        OnEnterCursor?.Invoke(isVisible);
    }
}