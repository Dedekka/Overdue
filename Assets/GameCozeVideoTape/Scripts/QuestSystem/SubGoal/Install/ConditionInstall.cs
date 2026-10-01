using UnityEngine;

public class ConditionInstall : Condition
{
    private DecorPresentSystem _listenerPresentSystem;
    private bool _isComplited;

    private int _idItem = 1;
    
    public override void Initialization(GoalController goalController)
    {
        _listenerPresentSystem = goalController.GoalContext.ListenerPresentSystem.DecorPresentSystem;
        _isComplited = false;
        SetSub();
        Debug.Log($"{this.GetType()} Initialization");
    }

    public override bool CheckComplited()
    {
        return _isComplited;
    }

    private void SetSub()
    {
        _listenerPresentSystem.OnInstall += OnInstall;
    }

    private void SetUnSub()
    {
        _listenerPresentSystem.OnInstall -= OnInstall;
    }

    private void OnInstall(int idItem)
    {

        Debug.Log($"{this.GetType()}, OnInstall, idItem:{idItem}");
        if (idItem == _idItem)
        {
            CheckCondition();
        }

    }

    private void CheckCondition()
    {
        _isComplited = true;
        SetUnSub();
        Complited();
    }
}