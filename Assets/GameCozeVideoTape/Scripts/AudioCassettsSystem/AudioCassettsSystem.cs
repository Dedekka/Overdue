public class AudioCassettsSystem
{
    private AudioRecorder _audioRecorder;
    private AudioCassetteAnimation _audioCassetteAnimation;

    // —писок всех аудио кассет на полках

    // ѕри взаимодействии открывать нывые кассеты 

    // ѕри установке кассеты в магнитофон отслеживать уже запущенную кассету возвращать на полку

    // «апускать анимацию пролета кассеты 

    public AudioCassettsSystem(AudioRecorder audioRecorder)
    {
        _audioRecorder = audioRecorder;
    }

    public void SetMusic(int idMusic)
    {
        _audioRecorder.SetMusic(idMusic);
    }
}