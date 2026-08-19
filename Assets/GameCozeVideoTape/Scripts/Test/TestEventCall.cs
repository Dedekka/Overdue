using UnityEngine;
using Zenject;

public class TestEventCall : BazeInteracteble
{
    [SerializeField] private int _dialogId;
    //[SerializeField] private string[] _dialogName;
    private Phone _phone;

    [Inject]
    private void Construct(Phone phone)
    {
        _phone = phone;
    }

    private void Awake()
    {
        //_dialogName = new string[]
        //{
        //    DialogName.ChrisTurner,
        //    DialogName.NancyParker,
        //};
        _isShowPanelUse = true;
    }

    protected override void Interact()
    {
        _phone.SetDialogName(_dialogId);
    }

    //private void OnValidate()
    //{
    //    if (_dialogName.Length > 0) { return; }
    //    _dialogName = new string[]
    //   {
    //        DialogName.ChrisTurner,
    //        DialogName.NancyParker,
    //   };
    //}
}