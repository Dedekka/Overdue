using TMPro;
using UnityEngine;

public class ViewDialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _characterName;
    [SerializeField] private TextMeshProUGUI _dialogText;

    public void ControlVisible(bool isVisible)
    {
        if (gameObject.activeSelf == isVisible) { return; }

        gameObject.SetActive(isVisible);
    }

    public void SetName(string name)
    {
        if (_characterName.text == name) { return; }
        _characterName.SetText(name);
    }

    public void SetDialog(string dialogText)
    {
        if (_dialogText.text == dialogText) { return; }
        _dialogText.SetText(dialogText);
    }
}