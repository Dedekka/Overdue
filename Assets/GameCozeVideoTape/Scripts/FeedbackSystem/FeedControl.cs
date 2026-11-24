using UnityEngine;
using Zenject;

public class FeedControl : MonoBehaviour
{
    private ControlGameAnalytics _controlGameAnalytics;

    [Inject]
    public void Construct(ControlGameAnalytics controlGameAnalytics)
    {
        _controlGameAnalytics = controlGameAnalytics;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.None;
        _controlGameAnalytics.SendCompliteEvent(21);
    }
}