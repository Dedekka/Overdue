public class ControlOperaLanguage
{
    
    private DataOperaLanguage _dataOperaLanguage;
    private OperaLanguageSettings _operaLanguageSettings;
    private ControlSettings _controlSettings;
    private Subtitles _currentSubtitles;
    private Language _currentLanguage;

    public ControlOperaLanguage(DataOperaLanguage dataOperaLanguage, ControlSettings controlSettings)
    {
        _dataOperaLanguage = dataOperaLanguage;
        _controlSettings = controlSettings;
    }

    public void GetOperaLanguage(int idEpisode)
    {
        _currentLanguage = _controlSettings.Language;
        _operaLanguageSettings = _dataOperaLanguage.GetItem(idEpisode);
        _currentSubtitles = _operaLanguageSettings.GetLanguage(_currentLanguage);
    }

    public Subtitles GetSubtitles()
    {
        return _currentSubtitles;
    }

}
