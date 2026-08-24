using DG.Tweening;
using System;
using UnityEngine;
using Zenject;

public class TVSlot : BazeInteracteble
{
    [SerializeField] private GameObject _bodySlot;

    //private PlayerInventory _playerInventory;
    private Ease _ease;
    private float _time;
    public event Action OnPlayCasset;
    public event Action<bool> OnEnterCursor;

    [Inject]
    public void Construct(PlayerInventory playerInventory, ShelfSlotSettings settings)
    {
        //_playerInventory = playerInventory;
        _ease = settings.EaseSuccess;
        _time = settings.TimeSuccess;
    }

    private void Awake()
    {
        _isShowPanelUse = true;
    }

    protected override void Interact()
    {
        OnPlayCasset?.Invoke();
    }

    public void ControlVisible(bool isVisible)
    {
        //if (_isActiveSlot) { return; }
        //_bodySlot.VisibleSlot(isVisible);
        _isShowPanelUse = isVisible;
        _bodySlot.SetActive(isVisible);
    }

    public bool Install(CassetteObject cassetteObject, out CassetteObject tempCassette)
    {
        tempCassette = cassetteObject;
        bool isSuccessful = cassetteObject == null;

        if (isSuccessful) { return isSuccessful; }

        cassetteObject.Install(_bodySlot.transform, _ease, _time);

        return isSuccessful;
    }

    public override void EnterCursor(bool isVisible)
    {
        //if (_isActiveSlot) { return; }
        OnEnterCursor?.Invoke(isVisible);
    }
}