using UnityEngine;
using Zenject;

public class DisableUi : MonoBehaviour
{
     private ControlPauseMenuPanel _controlPauseMenuPanel;
    [SerializeField] private GameObject _panelSettings;
    [SerializeField] private GameObject _panelTutorial;
    [SerializeField]  private GameObject _panelButtonsPause;

    [Inject]
    public void Construct(ControlPauseMenuPanel controlPauseMenuPanel)
    {
        _controlPauseMenuPanel = controlPauseMenuPanel;
    }

    private void OnEnable()
    {
        _panelButtonsPause.SetActive(true);
    }

    private void OnDisable()
    {
        _panelSettings.SetActive(false);
        _panelTutorial.SetActive(false);
        _controlPauseMenuPanel.Back();
    }
}
