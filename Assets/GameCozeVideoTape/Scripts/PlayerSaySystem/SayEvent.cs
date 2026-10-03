public abstract class SayEvent
{
    public readonly int Id;
    protected ConditionSayEvent _conditionSayEvent;
    
    public SayEvent(int id, ConditionSayEvent conditionSayEvent)
    {
        Id = id;
        _conditionSayEvent = conditionSayEvent;
    }

    public void Initialization()
    {
        _conditionSayEvent.Initialization();
        SetSub();
    }

    protected virtual void Complited() { }

    protected void SetSub()
    {
        _conditionSayEvent.OnComplited += OnComplitedCondition;
    }

    protected virtual void OnComplitedCondition(ConditionSayEvent condition)
    {
        condition.OnComplited -= OnComplitedCondition;
        Complited();
        //Debug.Log($"{this.GetType()}, CheckComplited:{CheckComplited()}");
    }
}
