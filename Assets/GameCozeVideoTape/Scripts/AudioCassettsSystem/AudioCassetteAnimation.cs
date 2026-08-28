using DG.Tweening;
using UnityEngine;

public class AudioCassetteAnimation
{
    private AudioItemSlot _currentAudioItem;
    private Transform _recorderSlotPosition;

    private float _powerJumpAudioSlot;
    private float _powerJumpReturnAudioSlot;
    private float _timeJumpAudioSlot;
    private float _timeJumpReturnAudioSlot;

    public AudioCassetteAnimation(Transform recorderSlotPosition, SettingsLookItem settingsLookItem)
    {
        _recorderSlotPosition = recorderSlotPosition;
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
        MoveItem(_recorderSlotPosition.position, _recorderSlotPosition.rotation, _powerJumpAudioSlot, _timeJumpAudioSlot);
    }

    private void MoveItem(Vector3 position, Quaternion rotation, float power, float time)
    {
        _currentAudioItem.transform.DOJump(position, power, 1, time).Play();
        _currentAudioItem.transform.DORotateQuaternion(rotation, time).Play();

    }

    private void CheckLastSlot()
    {
        if (_currentAudioItem == null) { return; }
        _currentAudioItem.GetStartState(out Vector3 startPosition, out Quaternion startRotation);
        MoveItem(startPosition, startRotation, _powerJumpReturnAudioSlot, _timeJumpReturnAudioSlot);
        _currentAudioItem = null;
    }
}