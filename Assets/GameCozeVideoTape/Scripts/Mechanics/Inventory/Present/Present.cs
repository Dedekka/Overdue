using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Present : BazeInteracteble
{
    [SerializeField] private List<TextMeshPro> listText;
    private PickUpItem _pickUpItem;
    private StateItem _stateItem;
    private PresentSettings _presentSettings;

    public void SetPresentSettings(PresentSettings presentSettings)
    {
        _presentSettings = presentSettings;
        SetId(_presentSettings.NamePresent);
    }

    private void SetId(string text)
    {
        for (int i = 0; i < listText.Count; i++)
        {
            listText[i].SetText(text);
        }
    }

    protected override void Interact()
    {
        //if (_stateItem.IsHandSlot) { return; }

        //if (_pickUpItem.CheckFreeSlot())
        //{
        //    _stateItem.ControlHand(true);
        //    OnPickUp?.Invoke(this);
        //    //_pickUpItem.PickUp();
        //    _stateItem.Control(false);
        //}
    }
}
