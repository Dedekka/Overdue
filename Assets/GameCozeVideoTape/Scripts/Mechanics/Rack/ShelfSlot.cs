using UnityEngine;
using Zenject;

public class ShelfSlot : MonoBehaviour
{
    [SerializeField] private ContentSlot _slot;
    private Player _player;
    private CassetteObject _cassetteObject;
    private bool isEmpty => _cassetteObject == null;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    private void OnEnable()
    {
        _slot.OnInteract += CheckEmptySlot;
        _slot.OnEnterCursor += CheckEmptyHand;
    }

    private void OnDisable()
    {
        _slot.OnInteract -= CheckEmptySlot;
        _slot.OnEnterCursor -= CheckEmptyHand;
    }

    private void CheckEmptySlot()
    {
        if (!isEmpty) { return; }

        bool isNull = _slot.Install(_player.GetCassette(), out _cassetteObject);
        SubPickUp(isNull);
        _slot.gameObject.SetActive(isNull);
        //_slot.ControlVisible(isNull);
    }

    private void CheckEmptyHand(bool isHandCassette)
    {
        if (isHandCassette)
        {
            if (_player.CheckActiveCassette())
            {
                _slot.ControlVisible(isHandCassette);
            }
        }
        else
        {
            _slot.ControlVisible(isHandCassette);
        }
    }



    private void SubPickUp(bool isNull)
    {
        if (isNull) { return; }

        _cassetteObject.OnPickUp += OnPickUp;
    }

    private void OnPickUp(CassetteObject tempcassette)
    {
        tempcassette.OnPickUp -= OnPickUp;
        _slot.gameObject.SetActive(true);
        //_slot.ControlVisible(true);
        _cassetteObject = null;
    }
}