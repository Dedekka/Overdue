using System;
using UnityEngine;
using Zenject;

public class Present : BazeInteracteble, IItemble
{
    public PresentSettings PresentSettings => _presentSettings;
    public Rigidbody Rigidbody => _rigidbody;
    public Collider Collider => _collider;

    public Transform _body => transform;

    private PickUpItem _pickUpItem;
    private StateItem _stateItem;
    private PresentSettings _presentSettings;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private SelectedItemEffect _selectedItemEffect;
    //private bool _PickUp;

    public event Action<Present> OnPickUp;

    [Inject]
    private void Construct(PickUpItem PickUpItem, ViewRenderer ViewRenderer, StateItem stateItem, SelectedItemEffect selectedItemEffect)
    {
        _stateItem = stateItem;
        _pickUpItem = PickUpItem;
        _isShowPanelUse = true;
        _selectedItemEffect = selectedItemEffect;
    }


    public void Scroll(Transform transform)
    {
        _pickUpItem.StopMove();
        _pickUpItem.Scroll(transform);
    }

    public void Install()
    {
        //_PickUp = false;
        _pickUpItem.StopMove();
        Destroy(gameObject);
    }

    public void Drop()
    {
        //_PickUp = false;
        //OnDrop?.Invoke();
        _pickUpItem.StopMove();
        _stateItem.Drop();
    }

    public override void EnterCursor(bool isVisible)
    {
        _selectedItemEffect.ControlSelectedOutline(isVisible);
    }

    public void SetPresentSettings(PresentSettings presentSettings, string currentNamePresent)
    {
        _presentSettings = presentSettings;
        Description = currentNamePresent;
        Initialization();
    }

    protected override void Interact()
    {
        if (_stateItem.IsHandSlot) { return; }

        if (_pickUpItem.CheckFreeSlot())
        {
            //_PickUp = true;
            _selectedItemEffect.ClearEffects();
            _stateItem.ControlHand(true);
            OnPickUp?.Invoke(this);
            _stateItem.Control(false);
        }
    }

    private void Initialization()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _pickUpItem.SetBody(this);
        _stateItem.Initialization(this, _rigidbody);
        _selectedItemEffect.Initialization(GetComponentInChildren<MeshRenderer>());
    }
}
