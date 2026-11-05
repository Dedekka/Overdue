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
        if (callData.IDCassette < 1) { return; }
        _callData = callData;
        ActiveEvent();
    }

    private void ActiveEvent()
    {
        _returnedMover.Returned(_callData.IDCassette);
    }
}