using System;
using UnityEngine;
using Zenject;

public class ImporterCounterSlotCassetteUi : IDisposable, IInitializable
{
    private CounterSlotCassette _counterSlotCassette;
    private CounterSlotCassetteUi _counterSlotCassetteUi;
    private int _maxCountSlot;

    public ImporterCounterSlotCassetteUi(CounterSlotCassette counterSlotCassette, CounterSlotCassetteUi counterSlotCassetteUi)
    {
        _counterSlotCassette = counterSlotCassette;
        _counterSlotCassetteUi = counterSlotCassetteUi;
        _maxCountSlot = 0;
    }

    public void Initialize()
    {
        _counterSlotCassette.OnUpdateMaxCountSlot += OnUpdateMaxCountSlot;
        _counterSlotCassette.OnUpdateCountSuccessInstall += OnUpdateCountSuccessInstall;
        _counterSlotCassette.UpdateInfo();
    }

    public void Dispose()
    {
        _counterSlotCassette.OnUpdateMaxCountSlot -= OnUpdateMaxCountSlot;
        _counterSlotCassette.OnUpdateCountSuccessInstall -= OnUpdateCountSuccessInstall;
    }

    private void OnUpdateCountSuccessInstall(int successInstall)
    {
        Debug.Log($"ImporterCounterSlotCassetteUi, OnUpdateCountSuccessInstall: {successInstall}");
        string text = $"{successInstall}/{_maxCountSlot}";
        _counterSlotCassetteUi.UpdateTextCounter(text);
    }

    private void OnUpdateMaxCountSlot(int maxCountSlot)
    {
        Debug.Log($"ImporterCounterSlotCassetteUi, OnUpdateMaxCountSlot: {maxCountSlot}");
        _maxCountSlot = maxCountSlot;
    }
}