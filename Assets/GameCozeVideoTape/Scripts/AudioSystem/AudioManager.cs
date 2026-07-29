using FMODUnity;

public class AudioManager
{
    private EventReference _pickUp;
    private EventReference _snapCorrect;
    private EventReference _snapWrong;
    private EventReference _drop;

    public AudioManager(AudioSettings audioSettings)
    {
        _pickUp = audioSettings.PickUp;
        _snapCorrect = audioSettings.SnapCorrect;
        _snapWrong = audioSettings.SnapWrong;
        _drop = audioSettings.Drop;
    }

    public void PlayPickUp()
    {
        Play(_pickUp);
    }

    public void PlaySnapCorrect()
    {
        Play(_snapCorrect);
    }

    public void PlaySnapWrong()
    {
        Play(_snapWrong);
    }

    public void PlayDrop()
    {
        Play(_drop);
    }

    private void Play(EventReference eventReference)
    {
        if (!eventReference.IsNull)
        {
            RuntimeManager.PlayOneShot(eventReference);
        }
    }

    //public void Play()
    //{
    //    if (!_sound.IsNull)
    //    {
    //        RuntimeManager.PlayOneShot(_sound);
    //    }
    //}

    //public void PlayHit(Vector3 Pos = new Vector3()) // Вызов другого звука 
    //{
    //    FMOD.Studio.EventInstance playHit = RuntimeManager.CreateInstance(_sound); // Создаем событие Звука 

    //    playHit.set3DAttributes(RuntimeUtils.To3DAttributes(Pos)); // Мы вводим информацию об положении в 3Д , а                       
    //                                                               //(RuntimeUtils.To3DAttributes) переводит наш Vector3 В понятный для Код 

    //    //playHit.setParameterByName("Size", transform.localScale.x);// Мы отправляем значение для параметра Size , по хорошему нужно 
    //    // разобраться как использовать ID 
    //    playHit.start(); // Запускаем воспроизведение 
    //    playHit.release(); // освобождаем память от этого события 
    //}
}
