using System;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;

public class CounterSlotCassette : IDisposable
{
    private ManagerRack _managerRack;
    private FinderFreeSlot _finderFreeSlot;
    private CounterRackSlot _counterRackSlot;

    private int _maxCountSlot;
    private int _countSuccessInstall;

    public event Action<int> OnUpdateCountSuccessInstall;
    public event Action<int> OnUpdateMaxCountSlot;

    public CounterSlotCassette(FinderFreeSlot finderFreeSlot, CounterRackSlot counterRackSlot)
    {
        _finderFreeSlot = finderFreeSlot;
        _counterRackSlot = counterRackSlot;
    }

    public void Initialize(ManagerRack managerRack)
    {
        Debug.Log($"CounterSlotCassette!!!!!!!!!!!!!!!");
        _managerRack = managerRack;
        _finderFreeSlot.OnChanheCountSuccessInstall += OnChanheCountSuccessInstall;
        _counterRackSlot.OnFinderMaxCountSlot += OnFinderMaxCountSlot;
    }

    public void Dispose()
    {
        _finderFreeSlot.OnChanheCountSuccessInstall -= OnChanheCountSuccessInstall;
        _counterRackSlot.OnFinderMaxCountSlot -= OnFinderMaxCountSlot;
    }

    public void UpdateInfo()
    {
        OnUpdateMaxCountSlot?.Invoke(_maxCountSlot);
        OnUpdateCountSuccessInstall?.Invoke(_countSuccessInstall);
    }

    private void OnFinderMaxCountSlot(int count)
    {
        Debug.Log($"OnFinderMaxCountSlot: {count}");
        _maxCountSlot = count;
        OnUpdateMaxCountSlot?.Invoke(count);
        // Получаем максимально доступное количество слотов для заполнения
    }

    private void OnChanheCountSuccessInstall()
    {
        CountingSuccessInstall(_managerRack.Racks);

        // Срабатывает когда меняется количество верно поставленых кассет в стелажже
        // нужно брать все стелажи и сумировать количество кассет с них
    }

    private void CountingSuccessInstall(List<Rack> racks)
    {
        int countSuccessInstall = 0;
        foreach (Rack rack in racks)
        {
            countSuccessInstall += rack.CountSuccessInstall;
        }
        _countSuccessInstall = countSuccessInstall;
        OnUpdateCountSuccessInstall?.Invoke(countSuccessInstall);
    }

}