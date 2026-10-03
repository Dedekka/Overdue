using System;
using System.Collections.Generic;
using Zenject;

public class GoalFactory
{
    private DiContainer _container;
    private DataTutorialEvent _dataTutorialEvent;

    public GoalFactory(DataTutorialEvent dataTutorialEvent, DiContainer container)
    {
        _dataTutorialEvent = dataTutorialEvent;
        _container = container;
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
            TutorialEventType.OnMove => _container.Instantiate<ConditionMove>(),
            TutorialEventType.OnPickUp => _container.Instantiate<ConditionPickUp>(),
            TutorialEventType.OnDrop => _container.Instantiate<ConditionDrop>(),
            TutorialEventType.OnScroll => _container.Instantiate<ConditionScroll>(),
            TutorialEventType.OnShow => _container.Instantiate<ConditionShow>(),
            TutorialEventType.OnTv => _container.Instantiate<ConditionTv>(),
            TutorialEventType.OnPhone => _container.Instantiate<ConditionPhone>(),
            TutorialEventType.OnPresent => _container.Instantiate<ConditionPresent>(),
            TutorialEventType.OnReturned => _container.Instantiate<ConditionReturned>(),
            TutorialEventType.OnInstall => _container.Instantiate<ConditionInstall>(),
            TutorialEventType.OnChangeAudio => _container.Instantiate<ConditionChangeAudio>(),
            TutorialEventType.OnOpera => _container.Instantiate<ConditionOpera>(),
            _ => throw new NotImplementedException()
        };
        return tutorialEventType;
    }

    private Goal CreateGoal(int id, TutorialEventSettings settings, List<Condition> conditions)
    {
        TutorialEventType type = (TutorialEventType)id;
        Goal tutorialEventType = type switch
        {
            TutorialEventType.OnMove => _container.Instantiate<GoalMove>(new object[] { settings, conditions }),
            TutorialEventType.OnPickUp => _container.Instantiate<GoalPickUp>(new object[] { settings, conditions }),
            TutorialEventType.OnDrop => _container.Instantiate<GoalDrop>(new object[] { settings, conditions }),
            TutorialEventType.OnScroll => _container.Instantiate<GoalScroll>(new object[] { settings, conditions }),
            TutorialEventType.OnShow => _container.Instantiate<GoalShow>(new object[] { settings, conditions }),
            TutorialEventType.OnTv => _container.Instantiate<GoalTv>(new object[] { settings, conditions }),
            TutorialEventType.OnPhone => _container.Instantiate<GoalPhone>(new object[] { settings, conditions }),
            TutorialEventType.OnPresent => _container.Instantiate<GoalPresent>(new object[] {11, settings, conditions }),
            TutorialEventType.OnReturned => _container.Instantiate<GoalReturned>(new object[] { settings, conditions }),
            TutorialEventType.OnInstall => _container.Instantiate<GoalInstall>(new object[] {12, settings, conditions }),
            TutorialEventType.OnChangeAudio => _container.Instantiate<GoalChangeAudio>(new object[] { settings, conditions }),
            TutorialEventType.OnOpera => _container.Instantiate<GoalOpera>(new object[] { settings, conditions }),
            _ => throw new NotImplementedException()
        };
        return tutorialEventType;
    }
}
