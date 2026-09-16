using UnityEngine.InputSystem;
using Zenject;

public class CounterSlotCassetteSystem 
{
    private CounterSlotCassetteUi _counterSlotCassetteUi;
    private CounterSlotCassette _counterSlotCassette;

    //private int count;
    //private int maxCount = 10;
    //private string Text = "Counter:";
    
    public CounterSlotCassetteSystem(CounterSlotCassetteUi counterSlotCassetteUi, CounterSlotCassette counterSlotCassette)
    {
        _counterSlotCassetteUi = counterSlotCassetteUi;
        _counterSlotCassette = counterSlotCassette;
    }

    //public void Tick()
    //{
    //    if (Keyboard.current.spaceKey.wasPressedThisFrame)
    //    {
    //        count++;
    //        string text = $"{Text} {count}/{maxCount}";
    //        _counterSlotCassetteUi.UpdateTextCounter(text);

    //    }
    //}
}