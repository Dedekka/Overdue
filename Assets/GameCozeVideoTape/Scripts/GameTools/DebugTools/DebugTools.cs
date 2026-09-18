using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

public class DebugTools : MonoBehaviour
{
    [SerializeField] private GameObject _debugPanel;
    [SerializeField] private Button _okButton;

    //[SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TMP_InputField _inputField;
    private CounterSlotCassette _counterSlotCassette;

    [Inject]
    public void Construct(CounterSlotCassette counterSlotCassette)
    {
        _counterSlotCassette = counterSlotCassette;
    }

    private void Start()
    {
        _okButton.onClick.AddListener(() => SetCountSuccessInstall());
    }

    private void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            bool isvisible = _debugPanel.gameObject.activeSelf;
            _debugPanel.gameObject.SetActive(!isvisible);

            if (!isvisible)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void SetCountSuccessInstall()
    {
        int count = 0;
        if (int.TryParse(_inputField.text, out count))
        {
            _counterSlotCassette.CountingSuccessInstall(count);
        }
        else
        {
            _inputField.text = string.Empty;
        }
        Debug.Log($"SetCountSuccessInstall, inputField.text:{_inputField.text} count:{count}");
    }
}