using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class GamePadMenu : IInitializable
{
    private List<GameObject> _selectedPanel;
    private EventSystem _eventSystem;

    public GamePadMenu(List<GameObject> selectedPanel)
    {
        _selectedPanel = selectedPanel;
    }

    public void Initialize()
    {
        _eventSystem = EventSystem.current;
        
             Debug.Log($"Initialize, _eventSystem ={_eventSystem == null}");
        ActiveButton(0);
    }

    public void ActiveButton(int indexPanel)
    {
        //Debug.Log($"ActiveButton ={CheckButton(indexPanel)}");

        if (CheckButton(indexPanel))
        {
            ChangeButton(indexPanel);
        }
        else
        {
            Debug.LogError("Not Found ActiveButton");
        }
    }

    private bool CheckButton(int index)
    {
        bool isSuccess = true;

        if (_eventSystem == null) { isSuccess = false; }

        if (index >= _selectedPanel.Count) { isSuccess = false; }

        Debug.Log($"CheckButton, _eventSystem ={_eventSystem == null}, index >= _selectedPanel.Count {index >= _selectedPanel.Count}");
        return isSuccess;
    }

    private void ChangeButton(int index)
    {
        GameObject SelectedGameObject = _selectedPanel[index];
        _eventSystem.SetSelectedGameObject(SelectedGameObject);
    }

    public void ChangeButton(GameObject SelectedGameObject)
    {
        if (SelectedGameObject == null) { return; }
        _eventSystem.SetSelectedGameObject(SelectedGameObject);
    }
}