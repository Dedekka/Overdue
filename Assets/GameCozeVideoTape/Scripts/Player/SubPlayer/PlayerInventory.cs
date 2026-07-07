using System;
using UnityEngine;
using Zenject;

public class PlayerInventory : IDisposable, IInitializable
{
    private readonly InventorySlot _inventorySlot;

    public PlayerInventory(InventorySlot inventorySlot)
    {
        _inventorySlot = inventorySlot;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    public void Drop()
    {
        _inventorySlot.Drop();
    }

    public void Scroll(Vector2 vector)
    {
        _inventorySlot.Scroll(vector.y<0);
    }

    public bool CheckFreeSlot(CassetteObject CassetteObject, out Transform transform)
    {
        return _inventorySlot.CheckFreeSlot(CassetteObject,out transform);
    }
}