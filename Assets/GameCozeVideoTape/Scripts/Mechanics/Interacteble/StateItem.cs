using UnityEngine;

public class StateItem
{
    // Должен быть таймер включающий выключающий физику

    public Collider Collider => _collider;
    public bool IsHandSlot => _isHandSlot;
    private CassetteObject _currentCassette;
    private Collider _collider;
    private Rigidbody _rigidbody;
    private bool _isHandSlot;

    public void Initialization(CassetteObject cassetteObject, Rigidbody rigidbody)
    {
        _currentCassette = cassetteObject;
        _collider = _currentCassette.GetComponent<Collider>();
        _rigidbody = rigidbody;
    }

    public void Drop()
    {
        _currentCassette.transform.SetParent(null);
        Control(true);
        ControlHand(false);
    }

    public void OnFixed()
    {
        Timer();
    }

    public void Install()
    {
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