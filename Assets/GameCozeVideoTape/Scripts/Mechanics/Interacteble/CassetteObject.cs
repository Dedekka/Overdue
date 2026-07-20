using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class CassetteObject : BazeInteracteble
{
    public TextMeshPro textMeshPro;
    public Rigidbody Rigidbody => _rigidbody;
    //public bool IsInstall => _isInstall;
    private PickUpItem _pickUpItem;
    private InstallItem _installItem;
    private Rigidbody _rigidbody;
    private Collider _collider;
    //public bool _isInstall;

    public event Action<CassetteObject> OnPickUp;

    [Inject]
    public void Construct(PickUpItem PickUpItem, InstallItem installItem)
    {
        _pickUpItem = PickUpItem;
        _installItem = installItem;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _pickUpItem.SetBody(this, _rigidbody);
        _installItem.SetBody(this);
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
        //_isInstall = true;
        _pickUpItem.StopMove();
        _installItem.Install(transform,Ease, _time);
    }

    protected override void Interact()
    {
        if (_pickUpItem.CheckFreeSlot())
        {
            OnPickUp?.Invoke(this);
            _pickUpItem.PickUp();
            Control(false);
        }

        //if (_pickUpItem.PickUp())
        //{
        //    Control(false);
        //    //_collider.enabled = false;
        //    //_rigidbody.isKinematic = true;
        //}
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

}