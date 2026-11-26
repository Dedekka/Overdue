using UnityEngine;
using Zenject;

public class TriggerCutscene : MonoBehaviour
{
    private CutSceneController _cutSceneController;

    [Inject]
    public void Construct(CutSceneController cutSceneController)
    {
        _cutSceneController = cutSceneController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            ActiveEndCutscene();
        }
    }

    private void ActiveEndCutscene()
    {
        _cutSceneController.StartCutscene(4);
        gameObject.SetActive(false);
    }
}