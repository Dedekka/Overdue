using UnityEngine;

public class ConditionExit : Condition
{
    private bool isComplited;

    public override void Initialization(GoalController goalController)
    {
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
    }

    protected override void SetUnSub()
    {
    }
}
