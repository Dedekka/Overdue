using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class SubtitlesWaiter
{
    public event Action OnEndWait;
    private bool _isWait;

    public SubtitlesWaiter()
    {
        _isWait = false;
    }

    public void StartWait(Subtitles Subtitles)
    {
        if (_isWait) { return; }
        Debug.Log($"StartWait, _isWait:{_isWait}");
        ProgressShow(Subtitles.TimeStart).Forget();
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
