using System;
using UnityEngine;

[Serializable]
public class ConditionMove : Condition
{
    private ListenerInputMove _listenerInputMove;

    private bool _moveW;
    private bool _moveA;
    private bool _moveS;
    private bool _moveD;
    
    public override void Initialization(GoalController goalController)
    {
        _listenerInputMove = goalController.GoalContext.ListenerInputMove;
        SetSub();
        Debug.Log($"GoalMove Initialization");
    }

    public override bool CheckComplited()
    {
        bool isComplited = false;

        isComplited = _moveW && _moveS && _moveA && _moveD;
        return isComplited;
    }

    private void SetSub()
    {
        _listenerInputMove._playerActions.Move.performed += OnMove;
    }

    private void SetUnSub()
    {
        _listenerInputMove._playerActions.Move.performed -= OnMove;
    }

    private void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext Callback)
    {
        Vector2 move = Callback.ReadValue<Vector2>();

        ControllDirection(move.x, true, ref _moveD);
        ControllDirection(move.x, false, ref _moveA);
        ControllDirection(move.y, true, ref _moveW);
        ControllDirection(move.y, false, ref _moveS);
        Debug.Log($"ConditionMove, Vector2:{move} ");
        CheckCondition();
        Debug.Log($"ConditionMove, _moveW:{_moveW}, _moveS: {_moveS}, _moveA{_moveA}, _moveD{_moveD} ");
    }

    private void ControllDirection(float Direction, bool isModifier, ref bool isCheckCondition)
    {
        bool isComplited = isCheckCondition;
        if (isCheckCondition) { return; }

        if (isModifier)
        {
            if (Direction > 0)
            {
                isComplited = true;
                isCheckCondition = isComplited;
            }
        }
        else
        {
            if (Direction < 0)
            {
                isComplited = true;
                isCheckCondition = isComplited;
            }
        }
    }

    private void CheckCondition()
    {
        bool isComplited = CheckComplited();

        if (isComplited)
        {
            SetUnSub();
            Complited();
        }
    }

}
