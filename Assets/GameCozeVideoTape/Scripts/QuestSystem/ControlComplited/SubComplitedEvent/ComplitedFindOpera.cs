using System.Collections.Generic;

public class ComplitedFindOpera : ComplitedHistoryEvent
{
    private InventoryCassette _listenerInventory;
    private List<int> _idFindCassette;
    private bool _isComplited;
    private bool _isActive;

    public ComplitedFindOpera(int id, int idEventHistory, List<int> idFindCassette, GoalController goalController) : base(id, idEventHistory, goalController)
    {
        _idFindCassette = idFindCassette;
        _listenerInventory = goalController.GoalContext.ListenerInventory.InventorySlot;
        _isComplited = false;
        _isActive = false;
    }

    public override bool CheckComplited(int idEventHistory)
    {
        if (!_isActive)
        {
            _isActive = true;
            SetSub();
        }
        return _isComplited;
    }

    public override void Complited()
    {
        _goalController.ActiveGoal(TutorialEventType.OnOpera);
    }

    private void SetSub()
    {
        _goalController.ChangeComplitedEvents();
        _listenerInventory.OnChangeSlot += OnChangeSlot;
    }

    private void SetUnSub()
    {
        _listenerInventory.OnChangeSlot -= OnChangeSlot;
    }

    private void OnChangeSlot(CassetteObject[] _activeCassets)
    {
        FindCassette(_activeCassets);
    }

    private void FindCassette(CassetteObject[] _activeCassets)
    {
        CassetteObject cassetteObject = _activeCassets[0];
        if (cassetteObject == null) { return; }

        _idFindCassette.Find((x) => x == cassetteObject.Id);
        if (_idFindCassette.Contains(cassetteObject.Id))
        {
            CheckCondition();
        }
    }

    private void CheckCondition()
    {
        _isComplited = true;
        SetUnSub();
        Complited();
    }
}
