using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlStatePanel : MonoBehaviour
{
    [SerializeField] private List<StatePanel> _statePanels;

    public void ChangeState(StatePanelUi state)
    {
        GameObject tempPanel = null;
        for (int i = 0; i < _statePanels.Count; i++)
        {
            _statePanels[i].Panel.gameObject.SetActive(false);

            if (_statePanels[i].StatePanelUi == state)
            {
                tempPanel = _statePanels[i].Panel;
            }
        }
        if (tempPanel == null) { return; }
        tempPanel.SetActive(true);
    }

}

public enum StatePanelUi
{
    Pause,
    Settings,
    Tutorial
}

[Serializable]
public class StatePanel
{
    public GameObject Panel;
    public StatePanelUi StatePanelUi;
}