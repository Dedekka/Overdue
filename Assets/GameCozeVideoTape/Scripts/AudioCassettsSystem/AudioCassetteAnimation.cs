using DG.Tweening;
using UnityEngine;

public class AudioCassetteAnimation
{
    private AudioItemSlot _currentAudioItem;
    private Transform _recorderSlotPosition;
    private Transform _preRecorderSlotPosition;
    //private Sequence _returnSequence;
    //private Sequence _recorderSequence;

    private float _powerJumpAudioSlot;
    private float _powerJumpReturnAudioSlot;
    private float _timeJumpAudioSlot;
    private float _timeJumpReturnAudioSlot;

    public AudioCassetteAnimation(Transform recorderSlotPosition, Transform preRecorderSlotPosition, SettingsLookItem settingsLookItem)
    {
        _recorderSlotPosition = recorderSlotPosition;
        _preRecorderSlotPosition = preRecorderSlotPosition;
        _powerJumpAudioSlot = settingsLookItem.PowerJumpAudioSlot;
        _timeJumpAudioSlot = settingsLookItem.TimeJumpAudioSlot;
        _powerJumpReturnAudioSlot = settingsLookItem.PowerJumpReturnAudioSlot;
        _timeJumpReturnAudioSlot = settingsLookItem.TimeJumpReturnAudioSlot;
    }

    public void SetItemSlot(AudioItemSlot audioItemSlot)
    {
        CheckLastSlot();
        _currentAudioItem = audioItemSlot;
        if (_currentAudioItem == null)
        {
            Debug.LogError("AudioCassetteAnimation Not Found AudioItemSlot");
            return;
        }
        MoveRecorderItem(_recorderSlotPosition.position, _recorderSlotPosition.rotation, _powerJumpAudioSlot, _timeJumpAudioSlot);
    }

    private void MoveReturnItem(Vector3 position, Quaternion rotation, float power, float time)
    {
        //CheckSequence(_returnSequence);
        Sequence _returnSequence = DOTween.Sequence();
        float fastTime = time / 2;
        //_currentAudioItem.ChangeInteractState(false);
        _returnSequence.Append(_currentAudioItem.transform.DOMove(_preRecorderSlotPosition.position, fastTime));
        //_returnSequence.Join(_currentAudioItem.transform.DORotateQuaternion(_preRecorderSlotPosition.rotation, fastTime));
        _returnSequence.Join(_currentAudioItem.transform.DORotateQuaternion(rotation, time));
        _returnSequence.Append(_currentAudioItem.transform.DOJump(position, power, 1, time));
        _currentAudioItem.SetSequence(_returnSequence);
        //_returnSequence.OnComplete(() => _currentAudioItem.ChangeInteractState(true));
        //_returnSequence.Play();
    }

    private void MoveRecorderItem(Vector3 position, Quaternion rotation, float power, float time)
    {
        //CheckSequence(_recorderSequence);
        Sequence _recorderSequence = DOTween.Sequence();
        float fastTime = time / 2;

        _recorderSequence.Append(_currentAudioItem.transform.DOJump(_preRecorderSlotPosition.position, power, 1, time));
        //_recorderSequence.Join(_currentAudioItem.transform.DORotateQuaternion(_preRecorderSlotPosition.rotation, fastTime));
        _recorderSequence.Join(_currentAudioItem.transform.DORotateQuaternion(rotation, time));

        _recorderSequence.Append(_currentAudioItem.transform.DOMove(position, fastTime));
        _currentAudioItem.SetSequence(_recorderSequence);
        //_recorderSequence.Play();
    }

    private void CheckLastSlot()
    {
        if (_currentAudioItem == null) { return; }
        _currentAudioItem.GetStartState(out Vector3 startPosition, out Quaternion startRotation);

        MoveReturnItem(startPosition, startRotation, _powerJumpReturnAudioSlot, _timeJumpReturnAudioSlot);
        _currentAudioItem = null;
    }

    //private void CheckSequence(Sequence sequence)
    //{
    //    if (sequence == null) { return; }
    //    sequence.Complete();
    //}
}