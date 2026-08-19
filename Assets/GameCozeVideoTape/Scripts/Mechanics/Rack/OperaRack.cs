using Zenject;

public class OperaRack : Rack
{
    private OperaChecker _operaRack;

    [Inject]
    private void Construct(OperaChecker operaRack)
    {
        _operaRack = operaRack;
    }

    public override bool CheckCorrectSlot(int slotndex, ItemSettings itemSettings)
    {
        bool installState = false;
        if (_operaRack.CheckEpisode(itemSettings.Id))
        {
            OperaSettings operaSettings = _operaRack.GetOperaEpisode();
            installState = operaSettings.Id_Slot == slotndex;
        }
        // опера ли это

        // Сравнивать слот из оперы и занятый 
        OnChangeState(installState);
        return installState;
    }
}