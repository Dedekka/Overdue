using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class DialogWaiter
{
    private IDialoguebleLine _dialogLine;
    private UpdateDialogText _updateDialogText;
    private float _timeWaitChar;

    public event Action<UpdateDialogText> OnUpdateDialogText;

    public DialogWaiter(float timeWaitChar)
    {
        _timeWaitChar = timeWaitChar;
        _updateDialogText = new UpdateDialogText();
    }

    public void SetDialogLine(IDialoguebleLine dialogLine)
    {
        _dialogLine = dialogLine;
    }

    public async UniTask StartShow()
    {
        string characterName = _dialogLine.Character;
        string Text = _dialogLine.Line;
        string tempText = string.Empty;

        _updateDialogText.Character = characterName;

        Debug.Log($"Name:{characterName}, Text:{Text}  ");
        for (int i = 0; i < Text.Length; i++)
        {
            tempText += Text[i];
            _updateDialogText.Line = tempText;
            OnUpdateDialogText?.Invoke(_updateDialogText);
            await UniTask.Delay(TimeSpan.FromSeconds(_timeWaitChar));
        }
    }
}

public class UpdateDialogText : IDialoguebleLine
{
    public string Character { get; set; }
    public string Line { get; set; }
}