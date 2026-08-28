using UnityEngine;

public class AudioRecorderActiveTrigger : MonoBehaviour
{
    [SerializeField] private RecorderController _recorderController;

    private void OnEnable()
    {
        _recorderController.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _recorderController.gameObject.SetActive(false);
    }
}