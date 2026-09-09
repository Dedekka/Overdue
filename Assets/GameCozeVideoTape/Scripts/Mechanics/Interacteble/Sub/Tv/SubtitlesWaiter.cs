using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class SubtitlesWaiter
{
    private ControlOperaLanguage _controlOperaLanguage;
    private bool _isWait;
    public event Action OnEndWait;

    public SubtitlesWaiter(ControlOperaLanguage controlOperaLanguage)
    {
        _controlOperaLanguage = controlOperaLanguage;
        _isWait = false;
    }

    public void StartWait()
    {
        Subtitles subtitles = _controlOperaLanguage.GetSubtitles();
        if (_isWait) { return; }
        Debug.Log($"StartWait, _isWait:{_isWait}");
        ProgressShow(subtitles.TimeStart).Forget();
    }

    private async UniTask ProgressShow(float time)
    {
        Debug.Log($"ProgressShow, time:{time}");
        _isWait = true;
        await UniTask.Delay(TimeSpan.FromSeconds(time));
        EndWait();
    }

    private void EndWait()
    {
        Debug.Log($"ProgressShow, EndWait");
        OnEndWait?.Invoke();
        _isWait = false;
    }
}
