using DG.Tweening;
using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class CassetteObject : BazeInteracteble, IItemble
{
    public int Id => _id;
    public bool IsOpera => _isOpera;
    public Rigidbody Rigidbody => _rigidbody;
    public Collider Collider => _stateItem.Collider;
    public ItemSettings ItemSettings => _itemSettings;

    public Transform _body { get => transform; }

    [SerializeField] private int _id;
    private ItemSettings _itemSettings;
    private PickUpItem _pickUpItem;
    private StateItem _stateItem;
    private InstallItem _installItem;

    private Rigidbody _rigidbody;
    private ManagerCassette _managerCassette;
    private bool _isOpera;

    public event Action<CassetteObject> OnPickUp;
    public event Action OnDrop;

    [Inject]
    private void Construct(PickUpItem PickUpItem, InstallItem installItem, ManagerCassette managerCassette, StateItem stateItem)
    {
        _stateItem = stateItem;
        _pickUpItem = PickUpItem;
        _installItem = installItem;
        _managerCassette = managerCassette;
    }

    private void Awake()
    {
        _isOpera = false;
        _rigidbody = GetComponent<Rigidbody>();
        _managerCassette.AddCassette(this);
        _pickUpItem.SetBody(this);
        _installItem.SetBody(this);
        _stateItem.Initialization(this, _rigidbody);
        _isShowPanelUse = true;
    }

    #region Testing
    public void SetId(int id)
    {
        _id = id;
    }

    #endregion

    public void SetSettings(ItemSettings itemSettings)
    {
        _itemSettings = itemSettings;
        Description = _itemSettings.Original_Title;
    }

    public void SetOpera()
    {
        _isOpera = true;
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
        _pickUpItem.StopMove();
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
            _stateItem.Control(false);
        }
    }
}
