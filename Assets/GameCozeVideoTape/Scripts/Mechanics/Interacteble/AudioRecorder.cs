using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AudioRecorder : MonoBehaviour
{
    // Мне нужно здесь использовать по аналогии с стелажами жанров
    // список классов кассет с написания на них ID
    // Кассеты которые подбираеются обращаются к этому классу и активируют
    [SerializeField] private RecorderController _recorderController;
    [SerializeField] private List<DataAudioSlot> _dataAudioSlotList;
    private MusicControl _musicControl;

    [Inject]
    public void Construct(MusicControl musicControl)
    {
        _musicControl = musicControl;
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
        if (GetAudioSlot(id, out DataAudioSlot dataAudioSlot))
        {
            dataAudioSlot.AudioItem.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("AudioRecorder Not Found AudioSlot");
        }
    }

    public void SetMusic(int idMusic)
    {
        _musicControl.SetMusic(idMusic);
    }

    private void OnChangeStatePlaying()
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        Debug.Log("AudioRecorder_PlayMusic");
        _musicControl.PlayMusic();
    }

    private bool GetAudioSlot(int idSlot, out DataAudioSlot dataAudioSlot)
    {
        dataAudioSlot = null;
        dataAudioSlot = _dataAudioSlotList.Find(x => x.IndexAudioCassette == idSlot);
        return dataAudioSlot != null;
    }

    private void Initialization()
    {
        DataAudioSlot dataAudioSlot;
        for (int i = 0; i < _dataAudioSlotList.Count; i++)
        {
            dataAudioSlot = _dataAudioSlotList[i];
            dataAudioSlot.AudioItem.gameObject.SetActive(false);
            CheckCurrectId(dataAudioSlot.IndexAudioCassette, dataAudioSlot.AudioItem);
        }
    }

    private void CheckCurrectId(int id, AudioItem audioItem)
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
}

[Serializable]
public class DataAudioSlot
{
    public int IndexAudioCassette;
    public AudioItem AudioItem;
}