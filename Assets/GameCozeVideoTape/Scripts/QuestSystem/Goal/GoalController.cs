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
    private ControlGoalTextIcon _ñontrolGoalTextIcon;

    //ControlGoalTextIcon

    public GoalController(ListenerContext goalContext, GoalFactory goalFactory, QuestViewUi questViewUi, ControlGoalLanguage controlGoalLanguage, ControlComplited controlComplited, ControlGoalTextIcon ñontrolGoalTextIcon)
    {
        GoalContext = goalContext;
        _goals = new();
        _goalFactory = goalFactory;
        _questViewUi = questViewUi;
        _controlGoalLanguage = controlGoalLanguage;
        _controlComplited = controlComplited;
        _ñontrolGoalTextIcon = ñontrolGoalTextIcon;
    }

    public void Initialize()
    {
        // Îáðàùàìñÿ ê êîìóòî êòî ìîæåò íàì âåðíóòü ñïèñîê Goal
        Initialization();
    }

    public void Dispose()
    {

    }

    public void ChangeLanguage()
    {
        List<PanelQuestUi> tempPanelQuestUi = _questViewUi.GetPanelQuestUi();
        int tempIdQuest;
        for (int i = 0; i < tempPanelQuestUi.Count; i++)
        {
            tempIdQuest = tempPanelQuestUi[i].IdQuest;
            if (tempIdQuest <= 0) { continue; }
            ResetInitializationGoal(tempPanelQuestUi[i]);
            //SetInitializationGoal(tempIdQuest);
        }
    }

    public void OnChangeDevice()
    {
        List<PanelQuestUi> tempPanelQuestUi = _questViewUi.GetPanelQuestUi();
        int IdQuest;
        for (int i = 0; i < tempPanelQuestUi.Count; i++)
        {
            if (!tempPanelQuestUi[i].Select){ continue; }

            IdQuest = tempPanelQuestUi[i].IdQuest;

            if (IdQuest <= 0){ continue; }
            //SetInitializationGoal(IdQuest);
            ResetInitializationGoal(tempPanelQuestUi[i]);
        }
    }

    public void ActiveGoal(TutorialEventType type)
    {
        Goal currentGoal = _goals.Find((x) => x.Settings.TutorialEventType == type);
        currentGoal.Initialization(this);


        //string GoalText = _controlGoalLanguage.GetLanguage(currentGoal.Settings.Id);
        //GoalText = _ñontrolGoalTextIcon.CheckTagIcon(GoalText);
        //_questViewUi.Initialization(currentGoal.Settings.Id, GoalText);

        SetInitializationGoal(currentGoal.Settings.Id);
    }

    public void ClearGoal(TutorialEventType type)
    {
        _questViewUi.ClearPanel(((int)type));
        Goal currentGoal = _goals.Find((x) => x.Settings.TutorialEventType == type);
        currentGoal.Stop();
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

    private void SetInitializationGoal(int tempIdQuest)
    {
        string GoalText = _controlGoalLanguage.GetLanguage(tempIdQuest);
        GoalText = _ñontrolGoalTextIcon.CheckTagIcon(GoalText);
        _questViewUi.Initialization(tempIdQuest, GoalText);
    }

    private void ResetInitializationGoal(PanelQuestUi panelQuestUi)
    {
        string GoalText = _controlGoalLanguage.GetLanguage(panelQuestUi.IdQuest);
        GoalText = _ñontrolGoalTextIcon.CheckTagIcon(GoalText);
        panelQuestUi.Initialization(panelQuestUi.IdQuest, GoalText);
    }
}