using DG.Tweening;
using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class CassetteObject : BazeInteracteble
{
    public int Id => ItemSettings.Id;
    public Rigidbody Rigidbody => _rigidbody;
    public Collider Collider => _stateItem.Collider;
    public ItemSettings ItemSettings => _itemSettings;
    private PickUpItem _pickUpItem;
    private StateItem _stateItem;
    private InstallItem _installItem;

    private Rigidbody _rigidbody;
   [SerializeField] private ItemSettings _itemSettings;
    private CassetteRenderer _cassetteRenderer;
    private ManagerCassette _managerCassette;

    public event Action<CassetteObject> OnPickUp;
    public event Action OnDrop;

    [Inject]
    private void Construct(PickUpItem PickUpItem, InstallItem installItem, ManagerCassette managerCassette, CassetteRenderer cassetteRenderer, StateItem stateItem)
    {
        _stateItem = stateItem;
        _pickUpItem = PickUpItem;
        _installItem = installItem;
        _cassetteRenderer = cassetteRenderer;
        _managerCassette = managerCassette;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _managerCassette.AddCassette(this);
        _pickUpItem.SetBody(this, _rigidbody);
        _installItem.SetBody(this);
        _stateItem.Initialization(this, _rigidbody);
    }

    public void SetSettings(ItemSettings itemSettings)
    {
        _itemSettings = itemSettings;
        _cassetteRenderer.Initialization(this, _itemSettings.MaterialIndex);
        Description = _itemSettings.Original_Title;
    }

    public void Drop()
    {
        OnDrop?.Invoke();
        _pickUpItem.StopMove();
        _stateItem.Drop();
    }

    public void OnFixed()
    {
        _stateItem.OnFixed();
    }

    public void Scroll(Transform transform)
    {
        _pickUpItem.Scroll(transform);
    }

    public void Install(Transform transform, Ease Ease, float _time)
    {
        _pickUpItem.StopMove();
        _installItem.Install(transform, Ease, _time, _stateItem.Install);
    }

    protected override void Interact()
    {
        if (_stateItem.IsHandSlot) { return; }

        if (_pickUpItem.CheckFreeSlot())
        {
            _stateItem.ControlHand(true);
            OnPickUp?.Invoke(this);
            _pickUpItem.PickUp();
            _stateItem.Control(false);
        }
    }
}
