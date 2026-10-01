using System;
using UnityEngine;

[Serializable]
public abstract class Condition 
{
    public string Name;
    public event Action OnComplited;

    public virtual void Initialization(GoalController goalController)
    {
        // Тот кто будет инициировать этот квест должен облодать доступом к системе ввода быть инициированым в
        // Zenject и через него можно это отслеживать
    }

    public abstract bool CheckComplited();

    protected void Complited()
    {
        OnComplited?.Invoke();  
    }
}