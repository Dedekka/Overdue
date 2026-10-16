using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlRackLanguage 
{
    private List<RackGanre> _rackGanres;

    public void FindRackLanguage()
    {
        if (_rackGanres != null) { return; }
        _rackGanres = GameObject.FindObjectsByType<RackGanre>(FindObjectsInactive.Exclude,FindObjectsSortMode.None).ToList();
    }

    public void ChangeLanguage()
    {
        FindRackLanguage();
        if (_rackGanres == null) { return; }
        for (int i = 0; i < _rackGanres.Count; i++)
        {
            _rackGanres[i].ChangeLanguage();
        }
    }
}