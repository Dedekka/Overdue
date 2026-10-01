using UnityEngine;

public class ComplitedReturnedTwo : ComplitedHistoryEvent
{
    public ComplitedReturnedTwo(int id, int idEventHistory, GoalController goalController) : base(id, idEventHistory, goalController)
    {
    }

    public override void Complited()
    {
        _goalController.ActiveGoal(TutorialEventType.OnOpera);
    }
}
