using UnityEngine;

public class ComplitedReturnedTwo : ComplitedHistoryEvent
{
    private ControlOpera _controlOpera;

    public ComplitedReturnedTwo(int id, int idEventHistory, GoalController goalController, ControlOpera controlOpera) : base(id, idEventHistory, goalController)
    {
        _controlOpera = controlOpera;
    }

    public override void Complited()
    {
        _controlOpera.OnCassetteOpera();
    }
}