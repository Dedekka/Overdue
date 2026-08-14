using UnityEngine;
using Zenject;

public class ShelfSlot : MonoBehaviour, ISloteble
{
    [SerializeField] private ContentSlot _slot;
    private SubGenreShelf _subGenreShelf;
    private PlayerInventory _playerInventory;
    private CassetteObject _cassetteObject;
    public bool IsEmpty => _cassetteObject == null;
    private ShelfSlotSettings _settings;

    [Inject]
    public void Construct(PlayerInventory playerInventory, ShelfSlotSettings settings)
    {
        _playerInventory = playerInventory;
        _settings = settings;
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

    public void Load(CassetteObject cassetteObject)
    {
        _cassetteObject = cassetteObject;
        SubPickUp(IsEmpty);
        _slot.gameObject.SetActive(IsEmpty);
    }

    public void Initialization(SubGenreShelf subGenreShelf)
    {
        _subGenreShelf = subGenreShelf;
    }

    public bool TryGetIdCassette(out int id)
    {
        id = IsEmpty ? -1 : _cassetteObject.Id;
        return IsEmpty;
    }

    private void CheckEmptySlot(CassetteObject currentCassette)
    {
        if (!IsEmpty) { return; }

        if (_subGenreShelf.CheckGanre(currentCassette.ItemSettings))
        {
            _slot.SetSettings(_settings.EaseSuccess, _settings.TimeSuccess);
        }
        else
        {
            _slot.SetSettings(_settings.EaseNothing, _settings.TimeNothing);
        }

        IItemble tempItem = _playerInventory.Install(this);

        if (tempItem is CassetteObject present)
        {
            bool isNull = _slot.Install(present, out _cassetteObject);
            SubPickUp(isNull);
            _slot.gameObject.SetActive(isNull);
        }
        else
        {
            Debug.LogError("ShelfSlot_CheckEmptySlot Not Found Present ");
        }


    }

    private void CheckEmptyHand(bool isHandCassette)
    {
        if (isHandCassette)
        {
            if (_playerInventory.CheckActiveItem(this, out IItemble currentCassette))
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