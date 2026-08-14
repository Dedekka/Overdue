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

    public bool CheckActiveItem(ISloteble sloteble, out IItemble Item)
    {
        Item = null;
        bool result = false;
        if (sloteble is DecorChecker decorChecker)
        {
            result = _inventoryPresent.CheckActivePresent(out Present present);
            Item = present;
            return result;

            //return _inventorySlot.CheckFreeSlot(cassette);
        }
        else if (sloteble is ContentSlot contentSlot || sloteble is ShelfSlot shelfSlot)
        {
            result = _inventorySlot.CheckActiveCassette(out CassetteObject currentCassette);
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
            tempItem = _inventoryPresent.Install();
        }
        else if (sloteble is ShelfSlot shelfSlot)
        {
            tempItem = _inventorySlot.Install();
        }
        return tempItem;
    }

    public void Drop()
    {
        _inventorySlot.Drop();
        _inventoryPresent.Drop();
    }

    public void Scroll(Vector2 vector)
    {
        _inventorySlot.Scroll(vector.y < 0);
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
            return _inventorySlot.CheckFreeSlot(cassette);
        }
        else if (Item is Present present)
        {
            return _inventoryPresent.CheckFreeSlot(present);
        }
        return false;
    }

    public void DropAllCassette()
    {
        _inventorySlot.DropAllCassette();
    }

    public void DropAllPresent()
    {
        _inventoryPresent.Drop();
    }

  
}
