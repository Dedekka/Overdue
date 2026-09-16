using FMODUnity;
using UnityEngine;
using Zenject;

public class EventOne : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter _eventEmitter;
    private Phone _phone;

    [Inject]
    private void Construct(Phone phone)
    {
        _phone = phone;
    }

    public void Active()
    {
        _eventEmitter.Play();
        _phone.SetDialogName(1);
    }
}
