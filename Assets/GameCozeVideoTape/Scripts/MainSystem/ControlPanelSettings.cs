using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ControlPanelSettings : IDisposable, IInitializable, ISelected
{
    public int CountPage => _pageButtons.Count;
    private List<PageButton> _pageButtons;
    private GameObject _selectedPanel;

    public ControlPanelSettings(SettingsButton pageButtons)
    {
        _pageButtons = pageButtons.PageButtons;
    }

    public void Dispose()
    {
        _pageButtons[0].NextPage.onClick.RemoveAllListeners();
        _pageButtons[1].NextPage.onClick.RemoveAllListeners();
        _pageButtons[2].NextPage.onClick.RemoveAllListeners();
    }

    public void Initialize()
    {
        _pageButtons[0].NextPage.onClick.AddListener(() => ActivePanel(0));
        _pageButtons[1].NextPage.onClick.AddListener(() => ActivePanel(1));
        _pageButtons[2].NextPage.onClick.AddListener(() => ActivePanel(2));
    }

    public void ActivePanel(int idPanel)
    {
        if (CheckActivePanel(idPanel)) { return; }
        for (int i = 0; i < _pageButtons.Count; i++)
        {
            _pageButtons[i].LastPage.SetActive(false);
        }
        _pageButtons[idPanel].LastPage.SetActive(true);
        _selectedPanel = _pageButtons[idPanel].NextPage.gameObject;
    }

    private bool CheckActivePanel(int idPanel)
    {
        bool isUnSuccess = false;

        if (idPanel >= _pageButtons.Count) { isUnSuccess = true; }
        else if (_pageButtons[idPanel].LastPage.activeSelf) { isUnSuccess = true; }

        return isUnSuccess;
    }

    public GameObject SelectedPanel()
    {
        return _selectedPanel;
    }
}

public interface ISelected
{
    public int CountPage {  get; }
    public void ActivePanel(int idPanel);
    public GameObject SelectedPanel();
}