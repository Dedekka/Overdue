using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuControl : MonoBehaviour
{
   [SerializeField] private Button _buttonFeedbackMenu;
    private ControlSettings _controlSettings;

    [Inject]
    public void Construct(ControlSettings controlSettings)
    {
        _controlSettings = controlSettings;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.None;

        _buttonFeedbackMenu.gameObject.SetActive(!_controlSettings.IsComplitedFeedback);
    }
}
