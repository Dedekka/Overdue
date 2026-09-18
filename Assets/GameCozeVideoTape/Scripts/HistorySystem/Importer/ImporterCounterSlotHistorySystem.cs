using System;
using Zenject;

public class ImporterCounterSlotHistorySystem : IDisposable, IInitializable
{
    private CounterSlotCassette _counterSlotCassette;
    private HistorySystem _historySystem;

    public ImporterCounterSlotHistorySystem(CounterSlotCassette counterSlotCassette, HistorySystem historySystem)
    {
        _counterSlotCassette = counterSlotCassette;
        _historySystem = historySystem;
    }

    public void Initialize()
    {
        _counterSlotCassette.OnUpdateCountSuccessInstall += OnUpdateCountSuccessInstall;
    }

    public void Dispose()
    {
        _counterSlotCassette.OnUpdateCountSuccessInstall -= OnUpdateCountSuccessInstall;
    }

    private void OnUpdateCountSuccessInstall(int InstallCassette)
    {
        _historySystem.ProgressHistory(InstallCassette);
    }
}