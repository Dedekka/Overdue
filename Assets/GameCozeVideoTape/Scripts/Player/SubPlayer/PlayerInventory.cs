using UnityEngine;

public class PlayerInventory
{
    public readonly InventoryCassette InventorySlot;
    public readonly InventoryPresent InventoryPresent;

    public PlayerInventory(InventoryCassette inventorySlot, InventoryPresent inventoryPresent)
    {
        InventorySlot = inventorySlot;
        InventoryPresent = inventoryPresent;
    }

    public bool CheckActiveItem(ISloteble sloteble, out IItemble Item)
    {
        Item = null;
        bool result = false;
        if (sloteble is DecorChecker)
        {
            result = InventoryPresent.CheckActivePresent(out Present present);
            Item = present;
            return result;
        }
        else if (sloteble is ContentSlot || sloteble is BazeSlot || sloteble is OperaChecker || sloteble is TV)
        {
            result = InventorySlot.CheckActiveCassette(out CassetteObject currentCassette);
            Item = currentCassette;
            return result;
        }
        Debug.LogError("CheckActiveIItemble not Found");
        return false;
    }

    public IItemble Install(ISloteble sloteble)
    {
        IItemble tempItem = null;

        if (sloteble is DecorChecker decorChecker)
        {
            tempItem = InventoryPresent.Install();
        }
        else if (sloteble is BazeSlot || sloteble is TV)
        {
            tempItem = InventorySlot.Install();
        }
        return tempItem;
    }

    public void Drop()
    {
        InventorySlot.Drop();
        InventoryPresent.Drop();
    }

    public void Scroll(Vector2 vector)
    {
        InventorySlot.Scroll(vector.y < 0);
    }

    public bool CheckFreeSlot(IItemble Item)
    {
        // Здесь можно сделать развилку
        // Убрать CassetteObject вместо него вставить интерфейс
        // по приведению типа определять в какой инвентарь мы можем обратится
        // InventoryCassette либо сюда InventoryPresent

        // проверять чем является 

        if (Item is CassetteObject cassette)
        {
            return InventorySlot.CheckFreeSlot(cassette);
        }
        else if (Item is Present present)
        {
            return InventoryPresent.CheckFreeSlot(present);
        }
        return false;
    }

    public void DropAllCassette()
    {
        InventorySlot.DropAllCassette();
    }

    public void DropAllPresent()
    {
        InventoryPresent.Drop();
    }
}