using System;
using Zenject;

public class ImporterInventoryPresentDecorPresentSystem : IDisposable, IInitializable
{
    private InventoryPresent _inventoryPresent;
    private DecorPresentSystem _decorPresentSystem;

    public ImporterInventoryPresentDecorPresentSystem(InventoryPresent inventoryPresent, DecorPresentSystem decorPresentSystem)
    {
        _inventoryPresent = inventoryPresent;
        _decorPresentSystem = decorPresentSystem;
    }

    public void Initialize()
    {
        _inventoryPresent.OnChangeSlotPresent += OnChangeSlotPresent;
    }

    public void Dispose()
    {
        _inventoryPresent.OnChangeSlotPresent -= OnChangeSlotPresent;
    }

    private void OnChangeSlotPresent(Present present)
    {
        int idPresent = present == null ? -1: present.PresentSettings.IdPresent;
       
        _decorPresentSystem.ControlVisible(idPresent);
    }
}