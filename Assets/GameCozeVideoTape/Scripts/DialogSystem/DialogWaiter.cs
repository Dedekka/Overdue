using Cysharp.Threading.Tasks;
using System;

public class DialogWaiter
{
    private DialogLine _dialogLine;
    private UpdateDialogText _updateDialogText;
    private float _timeWaitChar;

    public event Action<UpdateDialogText> OnUpdateDialogText;

    public DialogWaiter(float timeWaitChar)
    {
        _timeWaitChar = timeWaitChar;
        _updateDialogText = new UpdateDialogText();
    }

    public void SetDialogLine(DialogLine dialogLine)
    {
        _dialogLine = dialogLine;
    }

    public async UniTask StartShow()
    {
        string characterName = _dialogLine.Character;
        string Text = _dialogLine.Line;
        string tempText = string.Empty;

        _updateDialogText.CharacterName = characterName;
        for (int i = 0; i < Text.Length; i++)
        {
            tempText += Text[i];
            _updateDialogText.Text = tempText;
            OnUpdateDialogText?.Invoke(_updateDialogText);
            await UniTask.Delay(TimeSpan.FromSeconds(_timeWaitChar));
        }
    }
}

public class UpdateDialogText
{
    public string CharacterName;
    public string Text;
}