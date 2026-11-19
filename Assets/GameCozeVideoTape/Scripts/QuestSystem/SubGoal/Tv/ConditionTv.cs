using UnityEngine;

public class ConditionTv : Condition
{
    private CheckerTvCassette _listenerTv;
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
        _listenerTv.OnCheckCassette += OnCheckOperaCassette;
    }

    protected override void SetUnSub()
    {
        _listenerTv.OnCheckCassette -= OnCheckOperaCassette;
    }

    private void OnCheckOperaCassette()
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