using UnityEngine;

public class DisableUi : MonoBehaviour
{
    [SerializeField] private ControlStatePanel _controlStatePanel;
    [SerializeField] private GameObject _panelSettings;
    [SerializeField] private GameObject _panelTutorial;
    [SerializeField]  private GameObject _panelButtonsPause;

    private void OnEnable()
    {
        _panelButtonsPause.SetActive(true);
    }

    private void OnDisable()
    {
        _panelSettings.SetActive(false);
        _panelTutorial.SetActive(false);
        _controlStatePanel.ChangeState(StatePanelUi.Pause);
    }
}
