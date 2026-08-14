using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class DialogEventManager
{
    // —оздать класс спавнер в котороый мы передадим CallData и он реализует спавн  огда сработает отложенное событие

    // ” нас должен быть класс отвечающий за возвращенные кассеты он будет брать Id
    //  ассеты и перемещать еЄ в коробку возвратов вызыва€ метод Drop


    // ” нас должен быть класс отвечающий за слоты подарков всего слотов 10
    // ѕри событии из спавнера мы создаем в пустом слоте подарок с нужной Id


    // 
    // если у нас несколько кассет должно прийти дл€ каждой кассеты создаетс€ свой класс отложенного ожидани€ 
    // ћожем сохран€ть в этом классе список отложенных реализаций
    // пробегатьс€ по ним в классе Itickeble если список пуст не пробегатьс€ 
    // » в момент когда таймер кончитс€ вызывать событие в классах реализаторах
    // он будет создавать класс отложенного спавна
    // ¬ отложенных событи€х должен быть таймер уменьшающийс€
    // “о какие реализаторы будут вызваны, данные о подарке и кассете
    // // при сохранении мы должны брать это отложенное ожидание и если таймер не = 0 то запускать таймер дальше 


    // ћы можем определ€ть тип ивента по параметрам событи€ и распредел€ть между реализаторами (—павнер, катсцена и тд ) 

    private RealizerPresent _presentSpawner;
    private RealizerReturned _returnedMover;
    private CallData _callData;

    public DialogEventManager(RealizerPresent presentSpawner, RealizerReturned returnedMover)
    {
        _presentSpawner = presentSpawner;
        _returnedMover = returnedMover;
    }

    public void SetCallData(CallData callData)
    {
        _callData = callData;
    }

    public void ActiveEvent()
    {
        Wait().Forget();
    }


    private async UniTaskVoid Wait()
    {
        await UniTask.Delay(3000);
        Debug.Log($"DialogEventManager: IdCassetts: {_callData.IdCassetts}, IDPresent: {_callData.IDPresent}");


        //_returnedMover.SetCallData(_callData);
        //if (_callData.IDPresent < 0) { return; }
        //_presentSpawner.SetCallData(_callData);

        CheckCorrectID(_callData.IdCassetts, _returnedMover.SetCallData);
        CheckCorrectID(_callData.IDPresent, _presentSpawner.SetCallData);

        Debug.Log("EndTimer");
    }

    private void CheckCorrectID(int id, Action<CallData> action)
    {
        if (id < 0) { return; }

        action?.Invoke(_callData);
    }
}