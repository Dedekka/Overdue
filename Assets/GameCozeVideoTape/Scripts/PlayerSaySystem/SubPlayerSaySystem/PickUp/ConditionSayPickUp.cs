public class ConditionSayPickUp : ConditionSayEvent
{
    private InventoryCassette _inventoryCassette;

    public ConditionSayPickUp(InventoryCassette listenerInventory)
    {
        _inventoryCassette = listenerInventory;
    }

    public override void Initialization()
    {
        SetSub();
    }

    private void SetSub()
    {
        _inventoryCassette.OnPickUp += OnPickUp;
    }

    private void SetUnSub()
    {
        _inventoryCassette.OnPickUp -= OnPickUp;
    }

    private void OnPickUp()
    {
        SetUnSub();
        Complited();
    }
}
