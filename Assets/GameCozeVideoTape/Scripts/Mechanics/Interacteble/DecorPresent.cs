using System;
using UnityEngine;
using Zenject;

public class DecorPresent : MonoBehaviour
{
    [SerializeField] private DecorSlot _decorSlot;
    public int IdItem {  get; private set; }

    private DecorChecker _decorChecker;

    public event Action<DecorPresent> OnInstall;

    [Inject]
    private void Construct(DecorChecker decorChecker)
    {
        _decorChecker = decorChecker;
    }

    public void Initialization(int idItem)
    {
        IdItem = idItem;
        _decorSlot.OnInteract += OnInteract;
    }

    private void OnDisable()
    {
        _decorSlot.OnInteract -= OnInteract;
    }

    public void OnControlVisible(bool isVisible)
    {
        if (_decorChecker.CheckEmptyHand(isVisible, IdItem))
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
        Debug.Log($"DecorPresent:{gameObject.name}, idItem:{IdItem}, OnInteract");
        if (_decorChecker.CheckEmptyHand(true, IdItem))
        {
            Debug.Log($"DecorPresent:{gameObject.name}, _decorChecker.CheckEmptyHand true");
            _decorSlot.ActiveSlot();
            _decorChecker.DestroyPresent();
            OnInstall?.Invoke(this);
        }
    }


}