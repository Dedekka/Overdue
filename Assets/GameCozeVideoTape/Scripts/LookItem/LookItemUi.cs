using TMPro;
using UnityEngine;
using Zenject;

public class LookItemUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameItem;
    [SerializeField] private GameObject _panelButton;
    [SerializeField] private GameObject _panelButtonGamePad;

    private ImporterMenuInputControlDevice _menuInputControlDevice;
    private DeviceType _deviceType;

    [Inject]
    public void Construct(ImporterMenuInputControlDevice importerMenuInputControlDevice)
    {
        _menuInputControlDevice = importerMenuInputControlDevice;
    }

    private void Awake()
    {
        _menuInputControlDevice.OnInputDevice += OnChangeDevice;
    }

    private void OnDestroy()
    {
        _menuInputControlDevice.OnInputDevice -= OnChangeDevice;
    }

    public void SetText(string text)
    {
        if (_nameItem.text == text) { return; }
        _nameItem.SetText(text);
        OnChangeDevice(_menuInputControlDevice.CurrentDevice);
    }

    private void OnChangeDevice(DeviceType obj)
    {
        if (obj == _deviceType) { return; }
        _deviceType = obj;
        if (obj == DeviceType.KeyboardMouse)
        {
            _panelButton.SetActive(true);
            _panelButtonGamePad.SetActive(false);
        }
        else
        {
            _panelButton.SetActive(false);
            _panelButtonGamePad.SetActive(true);
        }
    }
}
