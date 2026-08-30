using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AudioCassettsSystem
{
    
    private AudioRecorder _audioRecorder;
    private AudioCassetteAnimation _audioCassetteAnimation;
    private AudioRecorderAnimation _audioRecorderAnimation;
    private List<DataAudioSlot> _dataAudioSlotList;

    private AudioItemSlot _currentAudioItemSlot;
    
    public AudioCassettsSystem(AudioRecorder audioRecorder, AudioCassetteAnimation audioCassetteAnimation, AudioRecorderAnimation audioRecorderAnimation)
    {
        _audioRecorder = audioRecorder;
        _audioCassetteAnimation = audioCassetteAnimation;
        _audioRecorderAnimation = audioRecorderAnimation;
    }

    public void SetDataAudioSlotList(List<DataAudioSlot> dataAudioSlotList)
    {
        _dataAudioSlotList = dataAudioSlotList;
    }

    public void SetMusic(AudioItemSlot currentAudioItemSlot)
    {
        if (!_audioRecorder.IsReadyMusic) { return; }
        _currentAudioItemSlot = currentAudioItemSlot;
        _audioRecorder.SetMusic(_currentAudioItemSlot.Id);
        _audioRecorderAnimation.SetAudioCassette();
        _audioCassetteAnimation.SetItemSlot(currentAudioItemSlot);
    }

    public void CheckCurrectId(int id, AudioItem audioItem)
    {
        if (audioItem == null)
        {
            Debug.LogError($"CheckCurrectId Not Found AudioItem, ID:{id}");
            return;
        }
        if (audioItem.Id != id)
        {
            Debug.LogError($"IDSlot:{id}, audioItemID:{audioItem.Id}");
        }
    }

    public void ActiveAudioSlot(int id)
    {
        if (GetAudioSlot(id, out DataAudioSlot dataAudioSlot))
        {
            dataAudioSlot.AudioItem.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("AudioRecorder Not Found AudioSlot");
        }
    }

    private bool GetAudioSlot(int idSlot, out DataAudioSlot dataAudioSlot)
    {
        dataAudioSlot = null;
        dataAudioSlot = _dataAudioSlotList.Find(x => x.IndexAudioCassette == idSlot);
        return dataAudioSlot != null;
    }

   
}