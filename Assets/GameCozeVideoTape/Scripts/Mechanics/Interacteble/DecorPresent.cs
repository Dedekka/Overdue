using UnityEngine;
using Zenject;

public class DecorPresent : MonoBehaviour
{
    [SerializeField] private DecorSlot _decorSlot;
    [SerializeField] private int _idItem;

    private DecorChecker _decorChecker;

    [Inject]
    private void Construct(DecorChecker decorChecker)
    {
        _decorChecker = decorChecker;
    }

    private void Awake()
    {
        _decorSlot.OnEnterCursor += OnEnterCursor;
        _decorSlot.OnInteract += OnInteract;
    }

    private void OnDisable()
    {
        _decorSlot.OnEnterCursor -= OnEnterCursor;
        _decorSlot.OnInteract -= OnInteract;
    }

    private void OnInteract()
    {
        if (_decorChecker.CheckEmptyHand(true, _idItem))
        {
            _decorSlot.ActiveSlot();
            _decorChecker.DestroyPresent();
        }
    }

    private void OnEnterCursor(bool isVisible)
    {
        if (_decorChecker.CheckEmptyHand(isVisible, _idItem))
        {
            _decorSlot.ControlVisible(true);
        }
        else
        {
            _decorSlot.ControlVisible(false);
        }
    }
}