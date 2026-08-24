using TMPro;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] private CanvasGroup _otherGoup;
    [SerializeField] private GameObject _panelUse;
    [SerializeField] private GameObject _panelDescription;
    [SerializeField] private TextMeshProUGUI _textDescription;

    [SerializeField] private InventoryView _inventoryView;

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

    public void UpdateTextInventory(string textHeader, string textPanelHand)
    {
        _inventoryView.UpdateTextInventory(textHeader, textPanelHand);
    }

    public void InventoryView()
    {
        _inventoryView.Show();
    }

    public void ChangeOtherGoup(bool isVisible)
    {
        _otherGoup.alpha = isVisible ? 1 : 0;
    }
}
