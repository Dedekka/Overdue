using System;
using Zenject;

public class ImporterPresentPlayerInventory : IDisposable, IInitializable
{
    private InventoryCassette _inventoryCassette;
    private InventoryPresent _inventoryPresent;
    private PlayerInventory _playerInventory;

    public ImporterPresentPlayerInventory(InventoryPresent inventoryPresent, PlayerInventory playerInventory, InventoryCassette inventoryCassette)
    {
        _inventoryPresent = inventoryPresent;
        _playerInventory = playerInventory;
        _inventoryCassette = inventoryCassette;
    }

    public void Initialize()
    {
        _inventoryCassette.OnPickUp += OnPickUpCassette;
        _inventoryPresent.OnPickUp += OnPickUpPresent;
    }


    public void Dispose()
    {
        _inventoryPresent.OnPickUp -= OnPickUpPresent;
        _inventoryCassette.OnPickUp -= OnPickUpCassette;
    }

    private void OnPickUpPresent()
    {
        _playerInventory.DropAllCassette();
    }

    private void OnPickUpCassette()
    {
        _playerInventory.DropAllPresent();
    }
}
