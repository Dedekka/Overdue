using System.Collections.Generic;

public class ControlDialogLanguage
{
    private List<DialogLine> tempDialogLines;
    private DataDialogLanguage _dataDialogLanguage;
    private DialogLanguageSettings _dialogLanguageSettings;

    private Language _currentLanguage;
    private ControlSettings _controlSettings;

    public ControlDialogLanguage(DataDialogLanguage dataDialogLanguage, ControlSettings controlSettings)
    {
        _dataDialogLanguage = dataDialogLanguage;
        _controlSettings = controlSettings;
    }

    public void GetLanguage(int languageId)
    {
        _currentLanguage = _controlSettings.Language;
        _dialogLanguageSettings = _dataDialogLanguage.GetItem(languageId);
        tempDialogLines = _dialogLanguageSettings.GetLanguage(_currentLanguage);
    }

    public int GetCountDialogLine()
    {
        return tempDialogLines.Count;
    }

    public DialogLine GetDialogLine(int index)
    {
        if (CheckCurrectLanguage())
        {
            _currentLanguage = _controlSettings.Language;
            tempDialogLines = _dialogLanguageSettings.GetLanguage(_currentLanguage);
        }
        return tempDialogLines[index];
    }

    private bool CheckCurrectLanguage()
    {
        return _currentLanguage != _controlSettings.Language;
    }
}