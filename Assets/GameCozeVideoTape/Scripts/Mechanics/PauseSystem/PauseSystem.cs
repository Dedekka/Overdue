using System;
using UnityEngine;

public class PauseSystem 
{
    private GameObject _pausePanel;
    private bool isPause;
    public event Action<bool> OnChangeStatePause;
  
    public  PauseSystem ( GameObject gameObject )
    {
        _pausePanel = gameObject;
        isPause = false;
    }

    public void Pause()
    {
        isPause = !isPause;
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