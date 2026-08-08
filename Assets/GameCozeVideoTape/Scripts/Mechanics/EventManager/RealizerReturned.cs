public class RealizerReturned
{
    private ReturnedMover _returnedMover;
    private CallData _callData;

    public RealizerReturned(ReturnedMover returnedMover)
    {
        _returnedMover = returnedMover;
    }

    public void SetCallData(CallData callData)
    {
        _callData = callData;
        ActiveEvent();
    }

    private void ActiveEvent()
    {
        _returnedMover.Returned(_callData.IdCassetts);
    }
}