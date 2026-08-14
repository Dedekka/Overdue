using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Present : BazeInteracteble, IItemble
{
    public PresentSettings PresentSettings => _presentSettings;
    public Rigidbody Rigidbody => _rigidbody;
    public Collider Collider => _collider;

    public Transform _body => transform;

    [SerializeField] private List<TextMeshPro> listText;
    private PickUpItem _pickUpItem;
    private StateItem _stateItem;
    [SerializeField] private PresentSettings _presentSettings;
    private Rigidbody _rigidbody;
    private Collider _collider;

    [Inject]
    private void Construct(PickUpItem PickUpItem, ViewRenderer ViewRenderer, StateItem stateItem)
    {
        _stateItem = stateItem;
        _pickUpItem = PickUpItem;
        _isShowPanelUse = true;
    }


    public void Scroll(Transform transform)
    {
        _pickUpItem.StopMove();
        _pickUpItem.Scroll(transform);
    }

    public void Install()
    {
        _pickUpItem.StopMove();
        Destroy(gameObject);
    }

    public void Drop()
    {
        //OnDrop?.Invoke();
        _pickUpItem.StopMove();
        _stateItem.Drop();
    }

    public void SetPresentSettings(PresentSettings presentSettings)
    {
        _presentSettings = presentSettings;
        SetId(_presentSettings.NamePresent);
        Initialization();
    }

    private void SetId(string text)
    {
        for (int i = 0; i < listText.Count; i++)
        {
            listText[i].SetText(text);
            Description = text;
        }
    }

    protected override void Interact()
    {
        if (_stateItem.IsHandSlot) { return; }

        if (_pickUpItem.CheckFreeSlot())
        {
            _stateItem.ControlHand(true);
            //OnPickUp?.Invoke(this);
            _stateItem.Control(false);
        }
    }

    private void Initialization()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _pickUpItem.SetBody(this);
        _stateItem.Initialization(this, _rigidbody);
    }
}
