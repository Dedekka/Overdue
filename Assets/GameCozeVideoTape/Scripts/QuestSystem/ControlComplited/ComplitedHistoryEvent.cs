using UnityEngine;

public abstract class ComplitedHistoryEvent
{
    public readonly int Id;
    public readonly int IdEventHistory;
    protected GoalController _goalController;

    public ComplitedHistoryEvent(int id, int idEventHistory, GoalController goalController)
    {
        Id = id;
        IdEventHistory = idEventHistory;
        _goalController = goalController;
    }

    public bool CheckComplited(int idEventHistory)
    {
       return IdEventHistory == idEventHistory;
    }

    public virtual void Complited()
    {
        Debug.Log($"{this.GetType()}, Id:{Id}, IdEventHistory:{IdEventHistory}");
    }
}
