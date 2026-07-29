using System;
using UnityEngine;
using Zenject;

public class PlayerInventory : IDisposable, IInitializable
{
    private readonly InventorySlot _inventorySlot;
    //private readonly InventoryView _inventoryView;

    public PlayerInventory(InventorySlot inventorySlot)//, InventoryView inventoryView)
    {
        _inventorySlot = inventorySlot;
        //_inventoryView = inventoryView;
    }

    public void Initialize()
    {
        _inventorySlot.OnChangeSlot += OnChangeSlot;
    }

    public void Dispose()
    {
        _inventorySlot.OnChangeSlot -= OnChangeSlot;
    }

    public bool CheckActiveCassette(out CassetteObject currentCassette)
    {
        return _inventorySlot.CheckActiveCassette(out currentCassette);
    }

    public CassetteObject Install( )
    {
       return _inventorySlot.Install();
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

    public void Load()
    {
        _inventorySlot.Load();
    }

    private void OnChangeSlot(CassetteObject[] cassettes)
    {
        //_inventoryView.OnChangeSlot(cassettes);
    }
}