using DG.Tweening;
using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class CassetteObject : BazeInteracteble
{
    public Rigidbody Rigidbody => _rigidbody;
    [SerializeField] private int _id = 0;
    private PickUpItem _pickUpItem;
    private InstallItem _installItem;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private ItemSettings _itemSettings;
    private CassetteRenderer _cassetteRenderer;
    public event Action<CassetteObject> OnPickUp;

    [Inject]
    private void Construct(PickUpItem PickUpItem, InstallItem installItem, ManagerCassette managerCassette, CassetteRenderer cassetteRenderer)
    {
        _pickUpItem = PickUpItem;
        _installItem = installItem;
        _itemSettings = managerCassette.GetSettings(_id);
        _cassetteRenderer = cassetteRenderer;
        if (_itemSettings == null)
        {
            Debug.LogError($"Cassette: {gameObject.name}, Id: {_id} Not Found Settings");
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _pickUpItem.SetBody(this, _rigidbody);
        _installItem.SetBody(this);
        Renderer _renderer = GetComponent<Renderer>();
        _cassetteRenderer.Initialization(_renderer, _itemSettings.Material, _itemSettings.MaterialIndex);
    }

    private void Start()
    {
        Description = _itemSettings.Original_Title;
    }

    public void Drop()
    {
        _pickUpItem.StopMove();
        transform.SetParent(null);
        Control(true);
    }

    public void Scroll(Transform transform)
    {
        _pickUpItem.Scroll(transform);
    }

    public void Install(Transform transform, Ease Ease, float _time)
    {
        _pickUpItem.StopMove();
        _installItem.Install(transform, Ease, _time);
    }

    public void Control(bool isFree)
    {
        _collider.enabled = isFree;
        _rigidbody.isKinematic = !isFree;
    }

    public void Control(bool isCollider, bool isKinematic)
    {
        _collider.enabled = isCollider;
        _rigidbody.isKinematic = isKinematic;
    }
    protected override void Interact()
    {
        if (_pickUpItem.CheckFreeSlot())
        {
            OnPickUp?.Invoke(this);
            _pickUpItem.PickUp();
            Control(false);
        }
    }
}