using UnityEngine;
using Zenject;

public class ShelfSlot : MonoBehaviour
{
    [SerializeField] private ContentSlot _slot;
    private SubGenreShelf _subGenreShelf;
    private Player _player;
    private CassetteObject _cassetteObject;
    private bool isEmpty => _cassetteObject == null;
    private ShelfSlotSettings _settings;

    [Inject]
    public void Construct(Player player, ShelfSlotSettings settings)
    {
        _player = player;
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



    public void Initialization(SubGenreShelf subGenreShelf)
    {
        _subGenreShelf = subGenreShelf;
    }

    private void CheckEmptySlot(CassetteObject currentCassette)
    {
        if (!isEmpty) { return; }
        
        if (_subGenreShelf.CheckGanre(currentCassette.ItemSettings))
        {
            _slot.SetSettings(_settings.EaseSuccess, _settings.TimeSuccess);
        }else
        {
            _slot.SetSettings(_settings.EaseNothing, _settings.TimeNothing);
        }
        bool isNull = _slot.Install(_player.GetCassette(), out _cassetteObject);
        SubPickUp(isNull);
        _slot.gameObject.SetActive(isNull);
    }

    private void CheckEmptyHand(bool isHandCassette)
    {
        if (isHandCassette)
        {
            if (_player.CheckActiveCassette(out CassetteObject currentCassette))
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