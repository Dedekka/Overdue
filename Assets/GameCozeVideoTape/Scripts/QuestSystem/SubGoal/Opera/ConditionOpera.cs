using UnityEngine;

public class ConditionOpera : Condition
{
    private OperaChecker _listenerTv;
    private bool isComplited;

    public override void Initialization(GoalController goalController)
    {
        _listenerTv = goalController.GoalContext.ListenerTv.OperaChecker;
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
        _listenerTv.OnCheckOperaCassette += OnCheckOperaCassette;
    }

    protected override void SetUnSub()
    {
        _listenerTv.OnCheckOperaCassette -= OnCheckOperaCassette;
    }

    private void OnCheckOperaCassette(bool OnShow)
    {
        if (!OnShow) { return; }
        CheckCondition();
    }

    private void CheckCondition()
    {
        isComplited = true;
        SetUnSub();
        Complited();
    }
}