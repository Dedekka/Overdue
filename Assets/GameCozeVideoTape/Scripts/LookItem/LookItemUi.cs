using TMPro;
using UnityEngine;

public class LookItemUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameItem;

    public void SetText(string text)
    {
        if (_nameItem.text == text) { return; }
        _nameItem.SetText(text);
    }
}
