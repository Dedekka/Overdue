using System;

public class ControlFullScreenTutorial
{
    public bool IsActive => _isActive;
    private DataFullScreenTutorialKey _dataFullScreenTutorialKey;
    private FullScreenTutorialUi _fullScreenTutorialUi;
    private bool _isActive;
    public event Action<bool> OnStateFullScreenTutorial;

    public ControlFullScreenTutorial(FullScreenTutorialUi fullScreenTutorialUi, DataFullScreenTutorialKey dataFullScreenTutorialKey)
    {
        _fullScreenTutorialUi = fullScreenTutorialUi;
        _dataFullScreenTutorialKey = dataFullScreenTutorialKey;
    }

    public void ControlActive(bool isActive)
    {
        _isActive = isActive;
        _fullScreenTutorialUi.ControlActive(isActive);
        OnStateFullScreenTutorial?.Invoke(isActive);
        //OnStateFullScreenTutorial.
    }

    public void SetPanel(int id)
    {
        FindSettings(id);
    }

    private void FindSettings(int id)
    {
        FullScreenTutorialKeySettings fullScreenTutorialKeySettings = _dataFullScreenTutorialKey.GetTutorialSettings(id);
        _fullScreenTutorialUi.SetPanel(fullScreenTutorialKeySettings.KeyHeader, fullScreenTutorialKeySettings.KeyBody, fullScreenTutorialKeySettings.Video);
        ControlActive(true);
    }
}
//ImporterFullScreenTutorialLookItemEffects 