using UnityEngine;
using UnityEngine.Video;
using Zenject;

public class TV : MonoBehaviour, ISloteble
{
    [SerializeField] private TVSlot _tvSlot;
    private TvManager _tvManager;
    private VideoPlayer _videoPlayer;
    private OperaChecker _operatingChecker;
    private CassetteObject _cassetteObject;
    private PlayerInventory _playerInventory;
    public bool IsEmpty => _cassetteObject == null;
    // ѕровер€ть кассету в руках
    // есть ли на ней опера 

    [Inject]
    public void Construct(TvManager tvManager, OperaChecker operatingChecker, PlayerInventory playerInventory)
    {
        _playerInventory = playerInventory;
        _tvManager = tvManager;
        _operatingChecker = operatingChecker;
    }

    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _tvManager.Initialization(_videoPlayer);
        _tvSlot.OnPlayCasset += OnPlayCasset;
        _tvSlot.OnEnterCursor += OnEnterCursor;
    }

    private void OnDisable()
    {
        _tvSlot.OnPlayCasset -= OnPlayCasset;
        _tvSlot.OnEnterCursor -= OnEnterCursor;
    }

    public void OnEnterCursor(bool isVisible)
    {
        if (isVisible)
        {
            if (_playerInventory.CheckActiveItem(this, out IItemble currentCassette))
            {
                _tvSlot.ControlVisible(isVisible);
            }
        }
        else
        {
            _tvSlot.ControlVisible(isVisible);
        }
    }

    private void OnPlayCasset()
    {
        if (!IsEmpty) { return; }
        if (_operatingChecker.CheckHand(true))
        {
            _tvManager.OnPlayCasset();
            Install();
        }
    }

    private void Install()
    {
        IItemble tempItem = _playerInventory.Install(this);

        if (tempItem is CassetteObject cassette)
        {
            bool isNull = _tvSlot.Install(cassette, out _cassetteObject);
            SubPickUp(isNull);
            _tvSlot.gameObject.SetActive(isNull);
        }
        else
        {
            Debug.LogError("ShelfSlot_CheckEmptySlot Not Found Present ");
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
        _tvSlot.gameObject.SetActive(true);
        _tvSlot.ControlVisible(true);
        _cassetteObject = null;
        _tvManager.StopPlay();
    }
}