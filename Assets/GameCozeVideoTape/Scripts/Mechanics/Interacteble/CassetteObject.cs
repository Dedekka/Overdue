using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class CassetteObject : BazeInteracteble
{
    public Rigidbody Rigidbody => _rigidbody;
    private PickUpItem _pickUpItem;
    private Rigidbody _rigidbody;
    private Collider _collider;

    [Inject]
    public void Construct(PickUpItem PickUpItem)
    {
        _pickUpItem = PickUpItem;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _pickUpItem.SetBody(this, _rigidbody);
    }

    public void Drop()
    {
        _pickUpItem.Drop();
        transform.SetParent(null);
        _collider.enabled = true;
    }

    protected override void Interact()
    {
        if (_pickUpItem.PickUp())
        {
            _collider.enabled = false;
            _rigidbody.isKinematic = true;
        }
    }
}