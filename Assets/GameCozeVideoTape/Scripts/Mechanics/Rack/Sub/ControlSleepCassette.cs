using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ControlSleepCassette : IFixedTickable
{
    private List<CassetteObject> _listCassette;
    private float _timeWait;
    private float _time;

    public ControlSleepCassette(float timeWait)
    {
        _timeWait = timeWait;
    }

    public void SetCassette(List<CassetteObject> listCassette)
    {
        _listCassette = listCassette;
    }

    public void FixedTick()
    {
        if (_listCassette == null) { return; }
        if (_time > Time.time) { return; }
        _time = Time.time + _timeWait;
        for (int i = 0; i < _listCassette.Count; i++)
        {
            _listCassette[i].OnFixed();
        }
    }
}