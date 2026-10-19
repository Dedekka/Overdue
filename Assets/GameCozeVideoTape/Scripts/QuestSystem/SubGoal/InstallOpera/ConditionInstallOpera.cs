using UnityEngine;

public class ConditionInstallOpera : Condition
{
    private ManagerRack _managerRack;
    private OperaRack _operaRack;
    private bool isComplited;

    public ConditionInstallOpera (ManagerRack managerRack)
    {
        _managerRack = managerRack;
    }

    public override void Initialization(GoalController goalController)
    {
        isComplited = false;
        FindOperaRack();
        Debug.Log($"{this.GetType()} Initialization");
    }

    public override bool CheckComplited()
    {
        return isComplited;
    }

    protected override void SetSub()
    {
        _operaRack.OnInstallState += OnInstallState;
    }

    protected override void SetUnSub()
    {
        _operaRack.OnInstallState -= OnInstallState;
    }

    private void OnInstallState(bool OnShow)
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

    private void FindOperaRack()
    {
        Rack tempRack = _managerRack.Racks.Find((x) => x is OperaRack);
        if (tempRack != null)
        {
            if (tempRack is OperaRack operaRack)
            {
                _operaRack = operaRack;
                SetSub();
            }
        }
        else
        {
            Debug.LogError("Not Found OperaRack");
        }
    }
}