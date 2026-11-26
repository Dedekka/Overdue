using TMPro;
using UnityEngine;

public class PanelQuestUi : MonoBehaviour
{
    public int IdQuest { get; private set; }
    public bool Select { get; private set; }

    [SerializeField] private TextMeshProUGUI _text;
    private bool _isVisible;

    public void Initialization(int idGoal, string GoalText)
    {
        IdQuest = idGoal;
        Select = true;
        _text.SetText(GoalText);
    }

    public void ClearPanel()
    {
        Select = false;
        IdQuest = -1;
        _text.text = string.Empty;
    }
}