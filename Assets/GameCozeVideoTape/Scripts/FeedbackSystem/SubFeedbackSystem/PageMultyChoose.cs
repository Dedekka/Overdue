using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageMultyChoose : MonoBehaviour, IPage
{

    public List<ToggleMulty> ToggleBooles => _toggleBooles;
    [SerializeField] private List<ToggleMulty> _toggleBooles;

    

    public bool CheckImage(int IdToggle)
    {
        return _toggleBooles.Find((x) => x.IdToggle == IdToggle).Toggle.isOn;
    }

    public void ChooseToggle(int IdToggle)
    {
        _toggleBooles.Find((x) => x.IdToggle == IdToggle).Toggle.enabled = true;
    }
}

[Serializable]
public class ToggleMulty
{
    public Toggle Toggle;
    public int IdToggle;
}

public interface IPage
{
    public bool CheckImage(int IdToggle);
}