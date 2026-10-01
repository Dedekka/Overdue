using UnityEngine;

public class ComplitedCallOne : ComplitedHistoryEvent
{
    public ComplitedCallOne(int id, int idEventHistory, GoalController goalController) : base(id, idEventHistory, goalController)
    {
    }

    public override void Complited()
    {
        _goalController.ClearGoal(TutorialEventType.OnMove);
        _goalController.ClearGoal(TutorialEventType.OnPickUp);
        _goalController.ClearGoal(TutorialEventType.OnDrop);
        _goalController.ClearGoal(TutorialEventType.OnScroll);
        _goalController.ClearGoal(TutorialEventType.OnShow);
        _goalController.ClearGoal(TutorialEventType.OnTv);
        _goalController.ActiveGoal(TutorialEventType.OnPhone);
    }
}
