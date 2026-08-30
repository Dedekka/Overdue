using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AudioRecorder : MonoBehaviour
{
    public bool IsReadyMusic => _recorderController.gameObject.activeSelf;
    [SerializeField] private RecorderController _recorderController;
    [SerializeField] private List<DataAudioSlot> _dataAudioSlotList;
    private AudioCassettsSystem _audioCassettsSystem;
    private MusicControl _musicControl;

    [Inject]
    public void Construct(MusicControl musicControl, AudioCassettsSystem audioCassettsSystem)
    {
        _musicControl = musicControl;
        _audioCassettsSystem = audioCassettsSystem;
    }

    private void OnEnable()
    {
        _recorderController.OnChangeState += OnChangeStatePlaying;
    }

    private void OnDisable()
    {
        _recorderController.OnChangeState -= OnChangeStatePlaying;
    }

    private void Start()
    {
        Initialization();
    }

    public void ActiveAudioSlot(int id)
    {
        _audioCassettsSystem.ActiveAudioSlot(id);
    }

    public void SetMusic(int idMusic)
    {
        if (!IsReadyMusic) { return; }
        Debug.Log("SetMusic");
        _musicControl.SetMusic(idMusic);
    }

    private void OnChangeStatePlaying()
    {
        if (!IsReadyMusic) { return; }
        PlayMusic();
    }

    private void PlayMusic()
    {
        Debug.Log("AudioRecorder_PlayMusic");
        _musicControl.PlayMusic();
    }

    private void Initialization()
    {
        DataAudioSlot dataAudioSlot;
        for (int i = 0; i < _dataAudioSlotList.Count; i++)
        {
            dataAudioSlot = _dataAudioSlotList[i];
            dataAudioSlot.AudioItem.gameObject.SetActive(false);
            _audioCassettsSystem.CheckCurrectId(dataAudioSlot.IndexAudioCassette, dataAudioSlot.AudioItem);
        }
        _audioCassettsSystem.SetDataAudioSlotList(_dataAudioSlotList);
    }
}

[Serializable]
public class DataAudioSlot
{
    public int IndexAudioCassette;
    public AudioItem AudioItem;
}