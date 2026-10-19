using UnityEngine;

public class ConditionPhone : Condition
{
    private Phone _listenerPhone;
    private bool isComplited;

    public override void Initialization(GoalController goalController)
    {
        _listenerPhone = goalController.GoalContext.ListenerPhone.Phone;
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
        _listenerPhone.OnStartCall += OnStartCall;
    }

    protected override void SetUnSub()
    {
        _listenerPhone.OnStartCall -= OnStartCall;
    }

    private void OnStartCall()
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
