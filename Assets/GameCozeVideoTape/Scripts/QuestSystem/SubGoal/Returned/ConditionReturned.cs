using UnityEngine;

public class ConditionReturned : Condition
{
    private InventoryCassette _listenerInventory;
    private bool isComplited;

    private int idFindCassette = 136;

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
        _listenerInventory.OnChangeSlot += OnChangeSlot;
    }

    private void SetUnSub()
    {
        _listenerInventory.OnChangeSlot -= OnChangeSlot;
    }

    private void OnChangeSlot(CassetteObject[] _activeCassets)
    {
        FindCassette(_activeCassets);
    }

    private void FindCassette(CassetteObject[] _activeCassets)
    {
        CassetteObject cassetteObject = _activeCassets[0];
        if (cassetteObject == null) { return; }

        if (cassetteObject.Id == idFindCassette)
        {
            CheckCondition();
        }
    }

    private void CheckCondition()
    {
        isComplited = true;
        SetUnSub();
        Complited();
    }
}
