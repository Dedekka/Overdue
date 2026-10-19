using UnityEngine;

public class ConditionPresent : Condition
{
    private InventoryPresent _listenerInventory;
    private bool isComplited;

    public override void Initialization(GoalController goalController)
    {
        _listenerInventory = goalController.GoalContext.ListenerInventory.InventoryPresent;
        isComplited = false;
        SetSub();
        Debug.Log($"{this.GetType()} Initialization");
    }

    public override bool CheckComplited()
    {
        return isComplited;
    }

    protected override void SetSub()
    {
        _listenerInventory.OnPickUp += OnPickUp;
    }

    protected override void SetUnSub()
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
