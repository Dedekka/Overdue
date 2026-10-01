using System;
using System.Collections.Generic;

public class GoalFactory
{
    private DataTutorialEvent _dataTutorialEvent;

    public GoalFactory(DataTutorialEvent dataTutorialEvent)
    {
        _dataTutorialEvent = dataTutorialEvent;
    }

    public List<Goal> GetGoal()
    {
        List<Goal> goals = new List<Goal>();
        int Count = _dataTutorialEvent.GetCount() + 1;
        for (int i = 1; i < Count; i++)
        {
            goals.Add(SetGoal(i));
        }
        return goals;
    }

    private Goal SetGoal(int IdTutorialEvent)
    {
        TutorialEventSettings settings = _dataTutorialEvent.GetTutorialEventSettings(IdTutorialEvent);

        List<Condition> conditions = new List<Condition>()
        {
            FindCondition(IdTutorialEvent)
        };
        return CreateGoal(IdTutorialEvent, settings, conditions);
    }

    private Condition FindCondition(int id)
    {
        TutorialEventType type = (TutorialEventType)id;
        Condition tutorialEventType = type switch
        {
            TutorialEventType.OnMove => new ConditionMove(),
            TutorialEventType.OnPickUp => new ConditionPickUp(),
            TutorialEventType.OnDrop => new ConditionDrop(),
            TutorialEventType.OnScroll => new ConditionScroll(),
            TutorialEventType.OnShow => new ConditionShow(),
            TutorialEventType.OnTv => new ConditionTv(),
            TutorialEventType.OnPhone => new ConditionPhone(),
            TutorialEventType.OnPresent => new ConditionPresent(),
            TutorialEventType.OnReturned => new ConditionReturned(),
            TutorialEventType.OnInstall => new ConditionInstall(),
            TutorialEventType.OnChangeAudio => new ConditionChangeAudio(),
            TutorialEventType.OnOpera => new ConditionOpera(),
            _ => throw new NotImplementedException()
        };
        return tutorialEventType;
    }

    private Goal CreateGoal(int id, TutorialEventSettings settings, List<Condition> conditions)
    {
        TutorialEventType type = (TutorialEventType)id;
        Goal tutorialEventType = type switch
        {
            TutorialEventType.OnMove => new GoalMove(settings, conditions),
            TutorialEventType.OnPickUp => new GoalPickUp(settings, conditions),
            TutorialEventType.OnDrop => new GoalDrop(settings, conditions),
            TutorialEventType.OnScroll => new GoalScroll(settings, conditions),
            TutorialEventType.OnShow => new GoalShow(settings, conditions),
            TutorialEventType.OnTv => new GoalTv(settings, conditions),
            TutorialEventType.OnPhone => new GoalPhone(settings, conditions),
            TutorialEventType.OnPresent => new GoalPresent(settings, conditions),
            TutorialEventType.OnReturned => new GoalReturned(settings, conditions),
            TutorialEventType.OnInstall => new GoalInstall(settings, conditions),
            TutorialEventType.OnChangeAudio => new GoalChangeAudio(settings, conditions),
            TutorialEventType.OnOpera => new GoalOpera(settings, conditions),
            _ => throw new NotImplementedException()
        };
        return tutorialEventType;
    }
}
