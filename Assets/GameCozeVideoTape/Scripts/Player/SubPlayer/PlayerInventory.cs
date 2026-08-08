using UnityEngine;

public class PlayerInventory
{
    private readonly InventoryCassette _inventorySlot;
    private readonly InventoryPresent _inventoryPresent;

    public PlayerInventory(InventoryCassette inventorySlot, InventoryPresent inventoryPresent)
    {
        _inventorySlot = inventorySlot;
        _inventoryPresent = inventoryPresent;
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
        // Здесь можно сделать развилку
        // Убрать CassetteObject вместо него вставить интерфейс
        // по приведению типа определять в какой инвентарь мы можем обратится
        // InventoryCassette либо сюда InventoryPresent

        // проверять чем является 

        return _inventorySlot.CheckFreeSlot(CassetteObject, out transform);
    }

    public void Load()
    {
        _inventorySlot.Load();
    }
}