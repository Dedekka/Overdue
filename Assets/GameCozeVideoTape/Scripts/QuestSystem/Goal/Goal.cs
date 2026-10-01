using System.Collections.Generic;
using UnityEngine;

public abstract class Goal
{

    public TutorialEventSettings Settings { get; private set; }
    public List<Condition> Conditions { get; private set; }
    protected GoalController _goalController;
    public bool IsComplited { get; private set; }
    private bool _isActive;

    public Goal(TutorialEventSettings settings, List<Condition> conditions)
    {
        Settings = settings;
        Conditions = conditions;
        IsComplited = false;
        _isActive = false;
    }

    public virtual void Initialization(GoalController goalController)
    {
        if (_isActive) return;

        _isActive = true;
        for (int i = 0; i < Conditions.Count; i++)
        {
            Conditions[i].Initialization(goalController);
        }
        _goalController = goalController;
    }

    public bool CheckComplited()
    {
        bool isComplited = false;
        for (int i = 0; i < Conditions.Count; ++i)
        {
            isComplited = Conditions[i].CheckComplited();

            if (!isComplited)
            {
                return false;
            }
        }
        return isComplited;
    }

    public virtual void Complited() { IsComplited = true; }
    protected void SetSub()
    {
        for (int i = 0; i < Conditions.Count; i++)
        {
            Conditions[i].OnComplited += OnComplitedCondition;
        }
    }

    protected virtual void OnComplitedCondition()
    {
        Debug.Log($"{this.GetType()}, CheckComplited:{CheckComplited()}");
    }
}