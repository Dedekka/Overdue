using System;
using System.Collections.Generic;
using UnityEngine;

public class FinderFreeSlot
{
    public event Action OnChanheCountSuccessInstall;

    public int CountFreeSlot(Rack rack)
    {
        List<DataShelf> _subGenreShelfs = rack.SubGenreShelfs;
        DataShelf dataShelf = null;
        int tempCountSlot = 0;

        for (int i = 0; i < _subGenreShelfs.Count; i++)
        {
            dataShelf = _subGenreShelfs[i];
            if (!dataShelf.SubGenreShelfs.gameObject.activeSelf) { continue; }
            tempCountSlot += CheckRack(rack, dataShelf);
        }
        Debug.Log($"CountFreeSlot: {tempCountSlot}, Name:{rack.gameObject.name}");
        return tempCountSlot;
    }

    private int CheckRack(Rack rack, DataShelf dataShelf)
    {
        int tempCountSlot = 0;
        if (rack is OperaRack cassette)
        {
            for (int i = 0; i < dataShelf.SubGenreShelfs.ShelfSlot.Length; i++)
            {
                if (dataShelf.SubGenreShelfs.ShelfSlot[i].gameObject.activeSelf)
                {
                    tempCountSlot++;
                }
            }
        }
        else
        {
            tempCountSlot = dataShelf.SubGenreShelfs.ShelfSlot.Length;
        }
        return tempCountSlot;
    }

    public void SubCounter(Rack rack)
    {
        rack.OnChanheCountSuccessInstall += CheckCounter;
    }

    public void UnSubCounter(Rack rack)
    {
        rack.OnChanheCountSuccessInstall -= CheckCounter;
    }

    private void CheckCounter()
    {
        OnChanheCountSuccessInstall?.Invoke();
    }
}
