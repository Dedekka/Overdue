using UnityEngine;

public class ListenerInventory 
{
    public readonly InventoryCassette InventorySlot;
    public readonly InventoryPresent InventoryPresent;

    public ListenerInventory(InventoryCassette inventorySlot, InventoryPresent inventoryPresent)
    {
        InventorySlot = inventorySlot;
        InventoryPresent = inventoryPresent;
    }
}