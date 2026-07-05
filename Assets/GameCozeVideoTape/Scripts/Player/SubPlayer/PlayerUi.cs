using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textDescription;
    [SerializeField] private Image _cursor;

    public void UpdateText(string text)
    {
        if (_textDescription == null) return;
        if (_textDescription.text == text) return;
        _textDescription.text = text;
    }

    public void ControlVisibleCursor(bool visible)
    {
        _cursor.enabled = visible;
    }
}