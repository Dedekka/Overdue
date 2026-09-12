using System;
using System.Collections.Generic;
using UnityEngine;

public class CounterRackSlot
{
    private FinderFreeSlot _finderFreeSlot;
    private int _countSlot;

    public event Action<int> OnFinderMaxCountSlot;

    public CounterRackSlot(FinderFreeSlot finderFreeSlot)
    {
        _finderFreeSlot = finderFreeSlot;
    }

    public void SubCounter(List<Rack> racks)
    {
        Rack testRack;
        int tempCountSlot = 0;
        for (int i = 0; i < racks.Count; i++)
        {
            testRack = racks[i];
            tempCountSlot += _finderFreeSlot.CountFreeSlot(testRack);
            _finderFreeSlot.SubCounter(testRack);
            //_audioRackImporter.SubCassette(testRack);
        }
        Debug.Log($"CounterRackSlot: {tempCountSlot}");
        
        _countSlot = tempCountSlot;
        OnFinderMaxCountSlot?.Invoke( _countSlot );
    }

    public void UnSubCounter(List<Rack> racks)
    {
        Rack testRack;
        for (int i = 0; i < racks.Count; i++)
        {
            testRack = racks[i];
            _finderFreeSlot.UnSubCounter(testRack);
            //_audioRackImporter.UnSubCassette(testRack);
        }
    }
}
