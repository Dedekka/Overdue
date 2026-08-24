using UnityEngine;

public interface IRealizerDialogueble
{
    public bool CheckId(int id);
    
    public int GetCountDialogLine();
    public IDialoguebleLine GetDialogLine(int index);

    public void SetDialogLine();
    public void StartDialog();
    public void EndDialog();
}
//Получить количество реплик из _dialogSystemCall
//Получить строку диалога из _dialogSystemCall
// Вызвать событие Set из _dialogSystemCall
//Вызвать событие Start из _dialogSystemCall
//Вызвать событие End из _dialogSystemCall