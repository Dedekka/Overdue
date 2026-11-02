using System;
using UnityEngine;

public class PauseSystem 
{
    public bool IsPause => _isPause;
    private GameObject _pausePanel;
    private bool _isPause;
    public event Action<bool> OnChangeStatePause;
  
    public  PauseSystem ( GameObject gameObject )
    {
        _pausePanel = gameObject;
        _isPause = false;
    }

    public void Pause()
    {
        _isPause = !_isPause;
        ChangeState(_isPause);
    }

    public void Pause(bool isPause)
    {
        _isPause = isPause;
        ChangeState(isPause);
    }

    private void ChangeState( bool isPause)
    {
        Time.timeScale = isPause ? 0.0f : 1.0f;

        //if ( isPause )
        //{
        //    Time.timeScale = 0f;
        //    //Cursor.lockState = CursorLockMode.None;
        //}
        //else
        //{
        //    Time.timeScale = 1f;
        //    //Cursor.lockState = CursorLockMode.Locked;
        //}
        OnChangeStatePause?.Invoke( isPause );
        _pausePanel.SetActive( isPause );
    }
}