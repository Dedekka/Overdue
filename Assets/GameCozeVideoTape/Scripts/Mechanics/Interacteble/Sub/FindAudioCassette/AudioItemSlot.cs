using DG.Tweening;
using UnityEngine;
using Zenject;

public class AudioItemSlot : AudioItem
{
    private AudioCassettsSystem _audioCassettsSystem;
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Sequence _currentSequence;

    [Inject]
    public void Construct(AudioCassettsSystem audioCassettsSystem)
    {
        _audioCassettsSystem = audioCassettsSystem;
    }

    public void SetSequence(Sequence currentSequence)
    {
        _currentSequence?.Kill();
        _currentSequence = currentSequence;
        _currentSequence.Play();
    }

    public void GetStartState(out Vector3 startPosition, out Quaternion startRotation)
    {
        startPosition = _startPosition;
        startRotation = _startRotation;
    }

    protected override void Initialization()
    {
        SetStartState();
        base.Initialization();
    }

    protected override void OnInteract()
    {
        _audioCassettsSystem.SetMusic(this);
    }

    private void SetStartState()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }
}