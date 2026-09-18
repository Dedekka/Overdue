using UnityEngine;

public class StateItem
{
    public Collider Collider => _collider;
    public bool IsHandSlot => _isHandSlot;
    private IItemble _currentCassette;
    private Collider _collider;
    private Rigidbody _rigidbody;
    private bool _isHandSlot;
    private bool _isOffInteracteble;

    public void Initialization(IItemble cassetteObject, Rigidbody rigidbody)
    {
        _currentCassette = cassetteObject;
        _collider = _currentCassette._body.GetComponent<Collider>();
        _rigidbody = rigidbody;
        _isOffInteracteble = false;
    }

    public void Drop()
    {
        _currentCassette._body.SetParent(null);
        Control(true);
        ControlHand(false);
    }

    public void OnFixed()
    {
        Timer();
    }

    public void OffInteracteble()
    {
        ControlHand(true);
        Control(true, true);
        _isOffInteracteble = true;
    }

    public void Install()
    {
        if (_isOffInteracteble) { return; }
        ControlHand(false);
        Control(true, true);
    }

    public void ControlHand(bool isSlot)
    {
        _isHandSlot = isSlot;
    }

    public void Control(bool isFree)
    {
        _collider.enabled = isFree;
        _rigidbody.useGravity = isFree;
        _rigidbody.isKinematic = !isFree;
    }

    private void Timer()
    {
        if (_isHandSlot) { return; }
        if (_rigidbody.IsSleeping())
        {
            Control(true, true);
        }
    }

    private void Control(bool isCollider, bool isKinematic)
    {
        _collider.enabled = isCollider;
        _rigidbody.isKinematic = isKinematic;
        _rigidbody.useGravity = !isKinematic;
    }
}