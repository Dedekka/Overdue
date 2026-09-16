using UnityEngine;

public class DisableUi : MonoBehaviour
{
    [SerializeField] private GameObject _panelSettings;
    [SerializeField] private GameObject _panelTutorial;

    private void OnDisable()
    {
        _panelSettings.SetActive(false);
        _panelTutorial.SetActive(false);
    }
}
