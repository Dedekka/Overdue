using UnityEngine;
using Zenject;

public class DisableUi : MonoBehaviour
{
     private ControlPauseMenuPanel _controlPauseMenuPanel;

    [Inject]
    public void Construct(ControlPauseMenuPanel controlPauseMenuPanel)
    {
        _controlPauseMenuPanel = controlPauseMenuPanel;
    }

    private void OnEnable()
    {
        _controlPauseMenuPanel.OnEnable();
    }

    private void OnDisable()
    {
        _controlPauseMenuPanel.OnDisable();
    }
}