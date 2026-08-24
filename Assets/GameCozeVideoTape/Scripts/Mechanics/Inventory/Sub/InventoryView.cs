using DG.Tweening;
using TMPro;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject _panelHand;
    [SerializeField] private TextMeshProUGUI _textCurrent;
    [SerializeField] private TextMeshProUGUI _textPanelHand;
    [SerializeField] private float _duration;

    private Tween _tween;
    private RectTransform _rectTransform;

    private Vector2 _offSize;
    private Vector2 _onSize;
    private Vector2 _tempMovePanel;

    private bool _isVisible;

    private void Awake()
    {
        _rectTransform = _panelHand.GetComponent<RectTransform>();
        _offSize = new Vector2(0, 0.9f);
        _onSize = Vector2.zero;
    }

    public void UpdateTextInventory(string textHeader, string textPanelHand)
    {
        if (_textCurrent == null) return;
        if (_textCurrent.text == textHeader) return;
        //Debug.Log($"UpdateTextInventory: {text}");
        _textCurrent.text = textHeader;
        _textPanelHand.text = textPanelHand;

        bool isVisible = textHeader != string.Empty;
        _panelHand.SetActive(isVisible);
    }

    public void Show()
    {
        //Debug.Log($"PRE_RectTransform.sizeDelta: {_rectTransform.sizeDelta}");
        //Debug.Log($"PRE_RectTransform.anchorMin: {_rectTransform.anchorMin}");
        //Debug.Log($"PRE_RectTransform.anchorMinX: {_rectTransform.anchorMin.x}");
        //Debug.Log($"PRE_RectTransform.anchorMinY: {_rectTransform.anchorMin.y}");
        _isVisible = !_isVisible;
        _tempMovePanel = _isVisible ? _onSize : _offSize;

        _tween = _rectTransform.DOAnchorMin(_tempMovePanel, _duration)
                 .SetLink(gameObject);
        _tween.Play();
    }
}
