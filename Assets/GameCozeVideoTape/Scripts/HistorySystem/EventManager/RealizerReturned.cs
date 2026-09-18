public class RealizerReturned
{
    private ReturnedMover _returnedMover;
    private PresentEvent _callData;

    public RealizerReturned(ReturnedMover returnedMover)
    {
        _returnedMover = returnedMover;
    }

    public void SetCallData(PresentEvent callData)
    {
        _callData = callData;
        ActiveEvent();
    }

    private void ActiveEvent()
    {
        _returnedMover.Returned(_callData.IDCassette);
    }
}