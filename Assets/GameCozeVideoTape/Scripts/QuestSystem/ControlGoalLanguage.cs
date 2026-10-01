public class ControlGoalLanguage
{
    private DataTutorialEventLanguage _dataTutorialEventLanguage;
    private ControlSettings _controlSettings;
    private Language _currentLanguage;

    public ControlGoalLanguage(DataTutorialEventLanguage dataTutorialEventLanguage, ControlSettings controlSettings)
    {
        _dataTutorialEventLanguage = dataTutorialEventLanguage;
        _controlSettings = controlSettings;
    }

    public string GetLanguage(int id)
    {
        _currentLanguage = _controlSettings.Language;
       return _dataTutorialEventLanguage.GetLanguage(id).GetLanguage(_currentLanguage);
    }
}