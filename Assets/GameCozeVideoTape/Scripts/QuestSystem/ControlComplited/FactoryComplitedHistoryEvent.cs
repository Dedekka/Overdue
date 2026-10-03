using System.Collections.Generic;
using Zenject;

public class FactoryComplitedHistoryEvent
{
    private DiContainer _container;

    public FactoryComplitedHistoryEvent(DiContainer container)
    {
        _container = container;
    }

    public List<ComplitedHistoryEvent> GetComplitedEvents()
    {
        return CreateComplitedEvents();
    }

    private List<ComplitedHistoryEvent> CreateComplitedEvents()
    {
        List<ComplitedHistoryEvent> tempComplitedEvents = new List<ComplitedHistoryEvent>()
        {
            _container.Instantiate<ComplitedCallOne>(new object[] { 1, 1, 9 }),
            _container.Instantiate<ComplitedReturnedOne>(new object[] { 2, 2, 10 }),
            _container.Instantiate<ComplitedFindOpera>(new object[] { 3, -1, 8, new List<int>(){ 301,302,303 }}),
            _container.Instantiate<ComplitedReturnedTwo>(new object[] { 4, 4 }),
            _container.Instantiate<ComplitedDemoEnd>(new object[] { 5, 7, 16 })
        };

        return tempComplitedEvents;
    }
}