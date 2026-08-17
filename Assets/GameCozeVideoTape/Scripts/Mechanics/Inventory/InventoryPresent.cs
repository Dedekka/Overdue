using System;
using UnityEngine;

public class InventoryPresent
{
    private Present _currentPresent;
    private Transform _inventorySlot;
    private float _forceDropPresent;
    private bool _isFreeSlot => _currentPresent == null;

    public event Action OnPickUp;

    public InventoryPresent(Transform inventorySlot, SettingsPlayer settingsPlayer)
    {
        _inventorySlot = inventorySlot;
        _forceDropPresent = settingsPlayer.ForceDropPresent;
    }

    public Present Install()
    {
        if (_currentPresent == null) { return null; }
        Present temp = _currentPresent;
        _currentPresent = null;
        return temp;
    }

    public bool CheckActivePresent(out Present present)
    {
        present = _currentPresent;

        return present != null;
    }

    public bool CheckFreeSlot(Present present)
    {
        bool isSucsses = _isFreeSlot;
        if (_isFreeSlot)
        {
            _currentPresent = present;
            present.transform.SetParent(null);
            present.Scroll(_inventorySlot);
            OnPickUp?.Invoke();
        }
        return isSucsses;
    }

    public void Drop()
    {
        if (_isFreeSlot) { return; }

        _currentPresent.Drop();
        Vector3 direction = _inventorySlot.forward + _inventorySlot.up;

        _currentPresent.Rigidbody.AddForce(direction * _forceDropPresent, ForceMode.VelocityChange);

        _currentPresent = null;
    }
}