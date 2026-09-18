using FMODUnity;
using UnityEngine;
using Zenject;

public class EventTwo : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter _eventEmitter;
    private RealizerPresent _presentSpawner;
    private RealizerReturned _returnedMover;
    //private CallData _callData;

    [Inject]
    private void Construct(RealizerPresent presentSpawner, RealizerReturned returnedMover)
    {
        _presentSpawner = presentSpawner;
        _returnedMover = returnedMover;
    }

    public void Active()
    {
        _eventEmitter.Play();
        //_callData = new CallData()
        //{
        //    IdCassetts = 136,
        //    IDPresent = 1,
        //};
        //_returnedMover.SetCallData(_callData);
        //_presentSpawner.SetCallData(_callData);
    }
}
