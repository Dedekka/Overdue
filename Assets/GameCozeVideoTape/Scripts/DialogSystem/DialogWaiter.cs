using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

public class DialogWaiter : IDisposable
{
    private IDialoguebleLine _dialogLine;
    private UpdateDialogText _updateDialogText;
    private CancellationTokenSource _cancellationTokenSource;
    private float _timeWaitChar;
    private bool _isPlaying;

    public event Action<UpdateDialogText> OnUpdateDialogText;

    public DialogWaiter(float timeWaitChar)
    {
        _timeWaitChar = timeWaitChar;
        _updateDialogText = new UpdateDialogText();
        _isPlaying = false;
    }

    public void SetDialogLine(IDialoguebleLine dialogLine)
    {
        ControlEndToken();
        _dialogLine = dialogLine;
        _cancellationTokenSource = new CancellationTokenSource();
    }

    public bool CheckPrintChar()
    {
        return _isPlaying;
    }

    public void EndPrintChar()
    {
        _cancellationTokenSource?.Cancel();
    }

    public async UniTask StartShow()
    {
        await ProgressShow(_cancellationTokenSource.Token);
    }

    public async UniTask ProgressShow(CancellationToken token)
    {
        string characterName = _dialogLine.Character;
        string Text = _dialogLine.Line;
        string tempText = string.Empty;
        _isPlaying = true;
        _updateDialogText.Character = characterName;
        try
        {
            //Debug.Log($"Name:{characterName}, Text:{Text}  ");
            for (int i = 0; i < Text.Length; i++)
            {
                //Debug.Log($"tempText:{tempText}");
                tempText += Text[i];
                _updateDialogText.Line = tempText;
                OnUpdateDialogText?.Invoke(_updateDialogText);
                await UniTask.Delay(TimeSpan.FromSeconds(_timeWaitChar), cancellationToken: token);
            }
            _isPlaying = false;
        }
        catch (OperationCanceledException)
        {
            // нормальная отмена — не логируем
            _isPlaying = false;
            _updateDialogText.Line = Text;
            OnUpdateDialogText?.Invoke(_updateDialogText);
        }
        //finally
        //{

        //}
    }

    private void ControlEndToken()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
        _cancellationTokenSource = null;
    }

    public void Dispose()
    {
        ControlEndToken();
    }
}

public class UpdateDialogText : IDialoguebleLine
{
    public string Character { get; set; }
    public string Line { get; set; }
}
