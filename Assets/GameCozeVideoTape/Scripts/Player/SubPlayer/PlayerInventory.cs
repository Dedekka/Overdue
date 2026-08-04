using UnityEngine;

public class PlayerInventory
{
    private readonly InventorySlot _inventorySlot;
    public PlayerInventory(InventorySlot inventorySlot)
    {
        _inventorySlot = inventorySlot;
    }

    public bool CheckActiveCassette(out CassetteObject currentCassette)
    {
        return _inventorySlot.CheckActiveCassette(out currentCassette);
    }

    public CassetteObject Install()
    {
        return _inventorySlot.Install();
    }

    public void Drop()
    {
        _inventorySlot.Drop();
    }

    public void Scroll(Vector2 vector)
    {
        _inventorySlot.Scroll(vector.y < 0);
    }

    public bool CheckFreeSlot(CassetteObject CassetteObject, out Transform transform)
    {
        return _inventorySlot.CheckFreeSlot(CassetteObject, out transform);
    }

    public void Load()
    {
        _inventorySlot.Load();
    }
}