using TMPro;
using UnityEngine;

public class PanelQuestUi : MonoBehaviour
{
    public int IdQuest { get; private set; }
    public bool Select { get; private set; }

    [SerializeField] private TextMeshProUGUI _text;
    private bool _isVisible;

    public void Initialization(int idGoal, string GoalText)
    {
        IdQuest = idGoal;
        Select = true;
        _text.SetText(GoalText);
    }

    public void ClearPanel()
    {
        Select = false;
        IdQuest = -1;
        _text.text = string.Empty;
    }

    //public void UpdateTextInventory( string textPanel)
    //{
    //    if (_text == null) return;
    //    if (_text.text == textPanel) return;
    //    //Debug.Log($"UpdateTextInventory: {text}");
    //    _text.text = textPanel;

    //    bool isVisible = textPanel != string.Empty;
    //    gameObject.SetActive(isVisible);
    //}

    //public void Show()
    //{
    //    if (!gameObject.activeSelf) return;
    //    _isVisible = !_isVisible;
    //    //_tempMovePanel = _isVisible ? _onSize : _offSize;

    //    //_tween = _rectTransform.DOAnchorMin(_tempMovePanel, _duration)
    //    //         .SetLink(gameObject);
    //    //_tween.Play();
    //    //OnShow?.Invoke(_isVisible);
    //}
}