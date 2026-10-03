using System;
using System.Collections.Generic;
using Zenject;

public class GoalController : IInitializable, IDisposable
{
    public ListenerContext GoalContext { private set; get; }
    private List<Goal> _goals;
    private GoalFactory _goalFactory;
    private QuestViewUi _questViewUi;
    private ControlGoalLanguage _controlGoalLanguage;
    private ControlComplited _controlComplited;

    public GoalController(ListenerContext goalContext, GoalFactory goalFactory, QuestViewUi questViewUi, ControlGoalLanguage controlGoalLanguage, ControlComplited controlComplited)
    {
        GoalContext = goalContext;
        _goals = new();
        _goalFactory = goalFactory;
        _questViewUi = questViewUi;
        _controlGoalLanguage = controlGoalLanguage;
        _controlComplited = controlComplited;
    }

    public void Initialize()
    {
        // Обращамся к комуто кто может нам вернуть список Goal
        Initialization();
    }

    public void Dispose()
    {

    }

    public void ActiveGoal(TutorialEventType type)
    {
        Goal currentGoal = _goals.Find((x) => x.Settings.TutorialEventType == type);
        currentGoal.Initialization(this);
        string GoalText = _controlGoalLanguage.GetLanguage(currentGoal.Settings.Id);
        _questViewUi.Initialization(currentGoal.Settings.Id, GoalText);
    }

    public void ClearGoal(TutorialEventType type)
    {
        _questViewUi.ClearPanel(((int)type));
    }

    public void ChangeComplitedEvents()
    {
        _controlComplited.ChangeComplitedEvents();
    }

    private void Initialization()
    {
        _controlComplited.Initialization();
        _goals = _goalFactory.GetGoal();
        //Debug.Log($"_goals:{_goals.Count}");

        //for (int i = 0; i < _goals.Count; i++)
        //{
        //    Debug.Log($"Goals_ID:{_goals[i].Settings.Id}, TutorialEventType:{_goals[i].Settings.TutorialEventType}, Conditions:{_goals[i].Conditions.Count}");

        //    Condition tempCondition = _goals[i].Conditions[0];

        //    Debug.Log($"Goals_ID:{_goals[i].Settings.Id}, ConditionType:{tempCondition.GetType()}");
        //}
        ActiveGoal(TutorialEventType.OnMove);
    }
}