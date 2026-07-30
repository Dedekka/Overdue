using UnityEngine;

public class PauseSystem 
{
    private GameObject _pausePanel;
    private bool isPause;

    public  PauseSystem ( GameObject gameObject )
    {
        _pausePanel = gameObject;
        isPause = false;
    }

    public bool Pause()
    {
        isPause = !isPause;
        ChangeState(isPause);
        return isPause;
    }

    private void ChangeState( bool isPause)
    {
        if ( isPause )
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }

        _pausePanel.SetActive( isPause );
    }
}