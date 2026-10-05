using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageOneChoose : MonoBehaviour , IPage
{
    public List<ToggleSingle> ToggleBooles => _toggleBooles;
    [SerializeField] private List<ToggleSingle> _toggleBooles;

    public bool CheckImage(int IdToggle)
    {
        return _toggleBooles.Find((x) => x.IdToggle == IdToggle).Image.enabled;
    }

    public void ChooseToggle(int IdToggle)
    {
        for (int i = 0; i < _toggleBooles.Count; i++)
        {
            _toggleBooles[i].Image.enabled = false;
        }

        Debug.Log($"ChooseToggle: {IdToggle}");
        Image image = _toggleBooles.Find((x) => x.IdToggle == IdToggle).Image;

        if (image != null) { image.enabled = true; }

    }
}

[Serializable]
public class ToggleSingle
{
    public Image Image;
    public Button Button;
    public int IdToggle;
}