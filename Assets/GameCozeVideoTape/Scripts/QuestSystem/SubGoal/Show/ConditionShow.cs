using UnityEngine;

public class ConditionShow : Condition
{
    private InventoryView _listenerPlayerUi;
    private bool isComplited;

    private int countShow;
    private bool stateShow;

    public override void Initialization(GoalController goalController)
    {
        _listenerPlayerUi = goalController.GoalContext.ListenerPlayerUi.PlayerUi.InventoryView;
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
        _listenerPlayerUi.OnShow += OnShow;
    }

    private void SetUnSub()
    {
        _listenerPlayerUi.OnShow -= OnShow;
    }

    private void OnShow(bool OnShow)
    {
        if (stateShow != OnShow)
        {
            stateShow = OnShow;
            countShow++;
            Debug.Log($"ConditionShow, OnShow:{OnShow}, countShow:{countShow} ");
        }
        CheckCondition();
    }

    private void CheckCondition()
    {
        if (countShow < 2) { return; }

        isComplited = true;
        SetUnSub();
        Complited();
    }
}