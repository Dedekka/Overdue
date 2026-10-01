using System;
using UnityEngine;
using Zenject;

public class DecorPresent : MonoBehaviour
{
    [SerializeField] private DecorSlot _decorSlot;
    private int _idItem;

    private DecorChecker _decorChecker;

    public event Action<int> OnInstall;

    [Inject]
    private void Construct(DecorChecker decorChecker)
    {
        _decorChecker = decorChecker;
    }

    public void Initialization(int idItem)
    {
        _idItem = idItem;
        _decorSlot.OnInteract += OnInteract;
    }

    private void OnDisable()
    {
        _decorSlot.OnInteract -= OnInteract;
    }

    public void OnControlVisible(bool isVisible)
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

    private void OnInteract()
    {
        Debug.Log($"DecorPresent:{gameObject.name}, idItem:{_idItem}, OnInteract");
        if (_decorChecker.CheckEmptyHand(true, _idItem))
        {
            Debug.Log($"DecorPresent:{gameObject.name}, _decorChecker.CheckEmptyHand true");
            _decorSlot.ActiveSlot();
            _decorChecker.DestroyPresent();
            OnInstall?.Invoke(_idItem);
        }
    }


}