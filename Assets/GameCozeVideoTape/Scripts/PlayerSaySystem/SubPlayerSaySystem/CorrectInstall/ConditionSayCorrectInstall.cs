public class ConditionSayCorrectInstall : ConditionSayEvent
{
    private CounterSlotCassette _counterSlotCassette;

    public ConditionSayCorrectInstall(CounterSlotCassette counterSlotCassette)
    {
        _counterSlotCassette = counterSlotCassette;
    }

    public override void Initialization()
    {
        SetSub();
    }

    private void SetSub()
    {
        _counterSlotCassette.OnUpdateCountSuccessInstall += OnUpdateCountSuccessInstall;
    }

    private void SetUnSub()
    {
        _counterSlotCassette.OnUpdateCountSuccessInstall -= OnUpdateCountSuccessInstall;
    }

    private void OnUpdateCountSuccessInstall(int SuccessInstall)
    {
        if (SuccessInstall > 0)
        {
            SetUnSub();
            Complited();
        }
    }
}
