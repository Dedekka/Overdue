using UnityEngine;
using Zenject;

public class BazeSlot : MonoBehaviour, ISloteble
{
    public bool IsEmpty => _cassetteObject == null;
   [SerializeField] protected ContentSlot _slot;
    protected SubGenreShelf _subGenreShelf;
    protected PlayerInventory _playerInventory;
    protected CassetteObject _cassetteObject;
    protected ShelfSlotSettings _settings;
    protected int _idSlot;
    
    [Inject]
    public void Construct(ShelfSlotSettings settings,  PlayerInventory playerInventory)
    {
        _playerInventory = playerInventory;
        _settings = settings;
    }

    public void SetContentSlot(ContentSlot contentSlot)
    {
        _slot = contentSlot;
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

    public void Initialization(SubGenreShelf subGenreShelf,int idSlot)
    {
        _subGenreShelf = subGenreShelf;
        _idSlot = idSlot;
    }

    public bool TryGetIdCassette(out int id)
    {
        id = IsEmpty ? -1 : _cassetteObject.Id;
        return IsEmpty;
    }

    protected virtual void CheckEmptySlot(CassetteObject currentCassette)
    {
        if (!IsEmpty) { return; }

        if (_subGenreShelf.CheckCorrectSlot(currentCassette.ItemSettings))
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

    protected void SubPickUp(bool isNull)
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