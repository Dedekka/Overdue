using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class CassetteObject : BazeInteracteble //, ICassetteble
{
    private PickUpItem _pickUpItem;
    private Rigidbody _rigidbody;
    private Collider _collider;
    //public Transform Body => transform;

    [Inject]
    public void Construct(PickUpItem PickUpItem)
    {
        _pickUpItem = PickUpItem;
    }

    private void Awake()
    {
        _pickUpItem.SetBody(this);
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void Drop(Vector3 vector3)
    {
        _pickUpItem.Drop();
        transform.SetParent(null);
        _rigidbody.isKinematic = false;
        _collider.enabled = true;
        _rigidbody.AddForce(vector3, ForceMode.Impulse);
    }

    protected override void Interact()
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        _pickUpItem.PickUp();
    }
}