using System.Collections.Generic;
using UnityEngine;

public class AudioCassettsSystem
{
    private AudioRecorder _audioRecorder;
    private AudioCassetteAnimation _audioCassetteAnimation;
    private List<DataAudioSlot> _dataAudioSlotList;

    // —писок всех аудио кассет на полках

    // ѕри взаимодействии открывать нывые кассеты 

    // ѕри установке кассеты в магнитофон отслеживать уже запущенную кассету возвращать на полку

    // «апускать анимацию пролета кассеты 

    public AudioCassettsSystem(AudioRecorder audioRecorder)
    {
        _audioRecorder = audioRecorder;
    }

    public void SetDataAudioSlotList(List<DataAudioSlot> dataAudioSlotList)
    {
        _dataAudioSlotList = dataAudioSlotList;
    }

    public void SetMusic(int idMusic)
    {
        _audioRecorder.SetMusic(idMusic);
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