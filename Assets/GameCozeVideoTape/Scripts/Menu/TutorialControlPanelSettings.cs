using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TutorialControlPanelSettings : IDisposable, IInitializable, ISelected
{
    public int CountPage => _pageButtons.Count;
    private List<PageButton> _pageButtons;
    private GameObject _selectedPanel;

    public TutorialControlPanelSettings(TutorialsButton pageButtons)
    {
        _pageButtons = pageButtons.PageButtons;
    }
    public void Dispose()
    {

        _pageButtons[0].NextPage.onClick.RemoveAllListeners();
        _pageButtons[1].NextPage.onClick.RemoveAllListeners();
        _pageButtons[2].NextPage.onClick.RemoveAllListeners();
        _pageButtons[3].NextPage.onClick.RemoveAllListeners();
        _pageButtons[4].NextPage.onClick.RemoveAllListeners();
        _pageButtons[5].NextPage.onClick.RemoveAllListeners();
    }


    public void Initialize()
    {
        _pageButtons[0].NextPage.onClick.AddListener(() => ActivePanel(0));
        _pageButtons[1].NextPage.onClick.AddListener(() => ActivePanel(1));
        _pageButtons[2].NextPage.onClick.AddListener(() => ActivePanel(2));
        _pageButtons[3].NextPage.onClick.AddListener(() => ActivePanel(3));
        _pageButtons[4].NextPage.onClick.AddListener(() => ActivePanel(4));
        _pageButtons[5].NextPage.onClick.AddListener(() => ActivePanel(5));
    }

    public void ActivePanel(int idPanel)
    {
        if (CheckActivePanel(idPanel)) { return ; }
        for (int i = 0; i < _pageButtons.Count; i++)
        {
            _pageButtons[i].LastPage.SetActive(false);
        }
        _pageButtons[idPanel].LastPage.SetActive(true);
        _selectedPanel = _pageButtons[idPanel].NextPage.gameObject;
    }

    public GameObject SelectedPanel()
    {
        return _selectedPanel;
    }

    private bool CheckActivePanel(int idPanel)
    {
        bool isUnSuccess = false;

        if (idPanel >= _pageButtons.Count) { isUnSuccess = true; }
        else if (_pageButtons[idPanel].LastPage.activeSelf) { isUnSuccess = true; }

        return isUnSuccess;
    }



    //private void ControlStatePanel(int index)
    //{
    //    int count = _buttonsList.Count;
    //    if (index >= count)
    //    {
    //        Debug.LogError($"Index >= count Tutorial UI, Index:{index}, Count:{count}");
    //        return;
    //    }
    //    if (_buttonsList.Count != _panelsList.Count)
    //    {
    //        Debug.LogError($"Not found Full Ui, ButtonsList.Count:{_buttonsList.Count},PanelsList.Count{_panelsList.Count}");
    //        return;
    //    }

    //    for (int i = 0; i < count; i++)
    //    {
    //        _buttonsList[i].interactable = true;
    //        _panelsList[i].SetActive(false);
    //    }
    //    _buttonsList[index].interactable = false;
    //    _panelsList[index].SetActive(true);
    //}

}



public class TutorialsButton
{
    public readonly List<PageButton> PageButtons;

    public TutorialsButton(List<PageButton> pageButtons)
    {
        PageButtons = pageButtons;
    }
}
