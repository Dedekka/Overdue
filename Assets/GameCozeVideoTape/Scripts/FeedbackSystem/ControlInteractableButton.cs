using System;
using System.Collections.Generic;
using UnityEngine.UI;
using Zenject;

public class ControlInteractableButton : IInitializable, IDisposable
{
    private List<ControlFeedback> _controlFeedback;
    private List<PageButton> _pageButtons;

    public ControlInteractableButton(FactoryFeedback factoryFeedback, List<PageButton> pageButtons)
    {
        _controlFeedback = factoryFeedback.ControlFeedback;
        _pageButtons = pageButtons;
    }

    public void Initialize()
    {
        for (int i = 1; i < _pageButtons.Count; i++)
        {
            _pageButtons[i].NextPage.interactable = false;
        }

        for (int i = 0; i < _controlFeedback.Count; i++)
        {
            _controlFeedback[i].OnComplitedQuestion += ActiveInteractableButton;
        }
    }

    // Мы должны когда нажата кнопка или введен ответ в поле то кнопка далее становится доступна для нажатия 

    public void Dispose()
    {
        for (int i = 0; i < _controlFeedback.Count; i++)
        {
            _controlFeedback[i].OnComplitedQuestion -= ActiveInteractableButton;
        }
    }

    private void ActiveInteractableButton(int id, bool isComplitedQuestion)
    {
        PageButton pageButton = _pageButtons.Find((x) => x.IdPage == id);
        if (pageButton == null) { return; }
        pageButton.NextPage.interactable = isComplitedQuestion;
    }
}
