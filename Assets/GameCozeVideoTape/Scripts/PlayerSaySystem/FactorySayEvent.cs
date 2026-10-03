using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FactorySayEvent 
{
    private DiContainer _container;

    public FactorySayEvent(DiContainer container)
    {
        _container = container;
    }
    
    public List<SayEvent> GetComplitedEvents()
    {
        return CreateComplitedEvents();
    }
    
    private List<SayEvent> CreateComplitedEvents()
    {
        List<SayEvent> tempComplitedEvents = new List<SayEvent>()
        {
            _container.Instantiate<SayPickUp>(new object[] {
               1,6, _container.Instantiate<ConditionSayPickUp>()}),

            _container.Instantiate<SayCorrectInstall>(new object[] {
               2,7, _container.Instantiate<ConditionSayCorrectInstall>()}),
            
            _container.Instantiate<SayPlayMusic>(new object[] {
               3,13, _container.Instantiate<ConditionSayPlayMusic>()}),
        };
        return tempComplitedEvents;
    }
}