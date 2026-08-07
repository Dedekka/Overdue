using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataDialogue", menuName = "Create/DataDialogue")]
public class DataDialogue : ScriptableObject
{
    [SerializeField] private List<DialogSettings> _dialogues;
    private Dictionary<int, DialogSettings> _dialogData;

    private bool _checkDictionary => _dialogData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        _dialogues = mainGoogleSettings.Dialogues;
    }

    public DialogSettings GetDialog(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(_dialogues);
        }
        DialogSettings tempItem = _dialogData.TryGetValue(id, out DialogSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<DialogSettings> itemSettings)
    {
        _dialogData = new Dictionary<int, DialogSettings>();
        foreach (var item in itemSettings)
        {
            _dialogData.Add(item.Id, item);
        }
    }
}