using UnityEngine;

public class ConditionDrop : Condition
{
    private InventoryCassette _listenerInventory;
    private bool isComplited;

    public override void Initialization(GoalController goalController)
    {
        _listenerInventory = goalController.GoalContext.ListenerInventory.InventorySlot;
        isComplited = false;
        SetSub();
        Debug.Log($"ConditionDrop Initialization");
    }

    public override bool CheckComplited()
    {
        return isComplited;
    }

    private void SetSub()
    {
        _listenerInventory.OnDrop += OnDrop;
    }

    private void SetUnSub()
    {
        _listenerInventory.OnDrop -= OnDrop;
    }

    private void OnDrop()
    {
        CheckCondition();
    }

    private void CheckCondition()
    {
        isComplited = true;
        SetUnSub();
        Complited();
    }

}
