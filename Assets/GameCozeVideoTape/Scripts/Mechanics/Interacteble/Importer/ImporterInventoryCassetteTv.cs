using System;
using Zenject;

public class ImporterInventoryCassetteTv : IDisposable, IInitializable
{
    private TV _tv;
    private InventoryCassette _inventoryCassette;

    public ImporterInventoryCassetteTv(TV tv, InventoryCassette inventoryCassette)
    {
        _tv = tv;
        _inventoryCassette = inventoryCassette;
    }

    public void Initialize()
    {
        _inventoryCassette.OnChangeSlot += OnChangeSlot;
    }

    public void Dispose()
    {
        _inventoryCassette.OnChangeSlot -= OnChangeSlot;
    }

    private void OnChangeSlot(CassetteObject[] obj)
    {
        //_tv.OnEnterCursor(true);
    }
}
