using System.Collections.Generic;
using UnityEngine;

public class QuestViewUi : MonoBehaviour
{
    [SerializeField] private List<PanelQuestUi> _panelQuests;

    public void Initialization(int idGoal, string GoalText)
    {
        if (_panelQuests == null) return;

        PanelQuestUi panelQuestUi = FindFreePanel();

        if (panelQuestUi == null) return;
        panelQuestUi.Initialization(idGoal, GoalText);
        panelQuestUi.gameObject.SetActive(true);
    }

    public void ClearPanel(int idGoal)
    {
        PanelQuestUi panelQuestUi = _panelQuests.Find((x) => x.IdQuest == idGoal && x.Select);
        if (panelQuestUi == null) return;
        panelQuestUi.ClearPanel();
        panelQuestUi.gameObject.SetActive(false);
    }

    private PanelQuestUi FindFreePanel()
    {
        for (int i = 0; i < _panelQuests.Count; i++)
        {
            if (!_panelQuests[i].Select)
            {
                return _panelQuests[i];
            }
        }
        return null;
    }
}