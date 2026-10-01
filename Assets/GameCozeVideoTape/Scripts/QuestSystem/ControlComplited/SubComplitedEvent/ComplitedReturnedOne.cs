using UnityEngine;

public class ComplitedReturnedOne : ComplitedHistoryEvent
{
    public ComplitedReturnedOne(int id, int idEventHistory, GoalController goalController) : base(id, idEventHistory, goalController)
    {
    }
    
    public override void Complited()
    {
        _goalController.ActiveGoal(TutorialEventType.OnPresent);
        _goalController.ActiveGoal(TutorialEventType.OnReturned);
    }
}
