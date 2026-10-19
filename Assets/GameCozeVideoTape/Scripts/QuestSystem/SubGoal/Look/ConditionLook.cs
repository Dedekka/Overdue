using UnityEngine;

public class ConditionLook : Condition
{
    private ListenerInputMove _listenerInputMove;

    private int _count = 2;
    private int _tempCount;

    public override void Initialization(GoalController goalController)
    {
        _listenerInputMove = goalController.GoalContext.ListenerInputMove;
        SetSub();
    }

    public override bool CheckComplited()
    {
        return _tempCount >= _count;
    }

    protected override void SetSub()
    {
        _listenerInputMove._playerActions.Aim.performed += OnAim;
    }

    protected override void SetUnSub()
    {
        _listenerInputMove._playerActions.Aim.performed -= OnAim;
    }

    private void OnAim(UnityEngine.InputSystem.InputAction.CallbackContext Callback)
    {
        _tempCount++;
        CheckCondition();
    }

    private void CheckCondition()
    {
        if (CheckComplited())
        {
            SetUnSub();
            Complited();
        }
    }
}