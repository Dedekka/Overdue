using UnityEngine;

public class ConditionPickUp : Condition
{
    private InventoryCassette _listenerInventory;
    private bool isComplited;

    public override void Initialization(GoalController goalController)
    {
        _listenerInventory = goalController.GoalContext.ListenerInventory.InventorySlot;
        isComplited = false;
        SetSub();
        Debug.Log($"{this.GetType()} Initialization");
    }
    
    public override bool CheckComplited()
    {
        return isComplited;
    }

    private void SetSub()
    {
        _listenerInventory.OnPickUp += OnPickUp;
    }

    private void SetUnSub()
    {
        _listenerInventory.OnPickUp -= OnPickUp;
    }

    private void OnPickUp()
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
