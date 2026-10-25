using UnityEngine;

public class GamePadSelecter
{
    private ControlPanelSettings _controlPanelSettings;
    private TutorialControlPanelSettings _tutorialControlPanelSettings;
    private GamePadMenu _gamePadMenu;

    private ISelected _currentPanel;

    private int _countPanel;
    private int _maxPanel;

    public GamePadSelecter(ControlPanelSettings controlPanelSettings, TutorialControlPanelSettings tutorialControlPanelSettings, GamePadMenu gamePadMenu)
    {
        _controlPanelSettings = controlPanelSettings;
        _tutorialControlPanelSettings = tutorialControlPanelSettings;
        _gamePadMenu = gamePadMenu;
    }


    public void ControlStatePanel(int idPanel)
    {
        if (idPanel == 1)
        {
            _currentPanel = _controlPanelSettings;
        }
        else if (idPanel == 2)
        {
            _currentPanel = _tutorialControlPanelSettings;
        }
        else
        {
            _currentPanel = null;
        }
        ResetId();

    }

    public void ChangePanel(float direction)
    {
        if (_currentPanel == null) { return; }

        if (direction > 0)
        {
            NextPage();
        }
        else
        {
            LastPage();
        }
    }

    private void NextPage()
    {
        ChangePane(true);
        _currentPanel.ActivePanel(_countPanel);
        ChangeSelectedPanel();
    }

    private void LastPage()
    {
        ChangePane(false);
        _currentPanel.ActivePanel(_countPanel);
        ChangeSelectedPanel();
    }

    private void ChangePane(bool isUp)
    {
        if (isUp)
        {
            _countPanel++;
            if (_countPanel >= _maxPanel)
            {
                _countPanel = 0;
            }
        }
        else
        {
            _countPanel--;
            if (_countPanel < 0)
            {
                _countPanel = _maxPanel - 1;
            }
        }
    }

    private void ChangeSelectedPanel()
    {
        GameObject tempSelectedPanel = _currentPanel.SelectedPanel();
        _gamePadMenu.ChangeButton(tempSelectedPanel);
    }

    private void ResetId()
    {
        _countPanel = 0;
        _maxPanel = 0;
        _controlPanelSettings.ActivePanel(_countPanel);
        _tutorialControlPanelSettings.ActivePanel(_countPanel);

        if (_currentPanel == null) { return; }
        _maxPanel = _currentPanel.CountPage;
    }
}