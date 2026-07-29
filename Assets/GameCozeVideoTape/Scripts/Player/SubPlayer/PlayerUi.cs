using TMPro;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] private GameObject _panelUse;

    [SerializeField] private GameObject _panelDescription;
    [SerializeField] private TextMeshProUGUI _textDescription;


    [SerializeField] private GameObject _panelHand;
    [SerializeField] private TextMeshProUGUI _textPanelHand;

    public void UpdateTextDescription(string text)
    {
        if (_textDescription == null) return;
        if (_textDescription.text == text) return;
        _textDescription.text = text;
        bool isVisible = text != string.Empty;
        _panelDescription.SetActive(isVisible);
    }

    public void ShowPanelUse(bool isVisible)
    {
        if (_panelUse.activeSelf == isVisible) { return; }
        _panelUse.SetActive(isVisible);
    }

    public void UpdateTextInventory(string text)
    {
        if (_textPanelHand == null) return;
        if (_textPanelHand.text == text) return;
        Debug.Log($"UpdateTextInventory: {text}");
        _textPanelHand.text = text;
        bool isVisible = text != string.Empty;
        _panelHand.SetActive(isVisible);
    }
}