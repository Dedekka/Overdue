using UnityEngine;

public class FeedControl : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.None;
    }
}