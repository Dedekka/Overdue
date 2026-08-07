using UnityEngine;

public class TestEventCall : BazeInteracteble
{
    [SerializeField] private Phone _phone;
    [SerializeField] private int _dialogId;
    [SerializeField] private string[] _dialogName;

    private void Awake()
    {
        _dialogName = new string[]
        {
            DialogName.ChrisTurner,
            DialogName.NancyParker,
        };
    }

    protected override void Interact()
    {
        _phone.SetDialogName(_dialogId);
    }

    private void OnValidate()
    {
        if (_dialogName.Length > 0) { return; }
        _dialogName = new string[]
       {
            DialogName.ChrisTurner,
            DialogName.NancyParker,
       };
    }
}