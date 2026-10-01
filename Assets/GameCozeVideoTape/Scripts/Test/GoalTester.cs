using UnityEngine;
using Zenject;

public class GoalTester : BazeInteracteble
{
    [SerializeField] private TutorialEventType _tutorialEventType;
    [SerializeField] private bool _isClearGoal;
    private GoalController _controller;

    [Inject]
    private void Construct(GoalController controller)
    {
        _controller = controller;
    }

    protected override void Interact()
    {
        if (_isClearGoal)
        {
            ClearGoal();
        }
        else
        {
            SetGoal();
        }
    }

    private void SetGoal()
    {
        _controller.ActiveGoal(_tutorialEventType);
    }

    private void ClearGoal()
    {
        _controller.ClearGoal(_tutorialEventType);
    }

}
