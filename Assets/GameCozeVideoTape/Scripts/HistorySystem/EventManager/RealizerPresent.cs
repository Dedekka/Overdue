using UnityEngine;

public class RealizerPresent
{
    // Содержишь систему спавна подарков
    // Содержишь PackageSystem
    // Когда пришло время обращаешся к системе спавна
    // и передаешь созданный подарок в PackageSystem

    private PresentSpawner _presentSpawner;
    private PackageSystem _packageSystem;
    private Present _currentPresent;
    private PresentEvent _callData;

    public RealizerPresent(PresentSpawner presentSpawner, PackageSystem packageSystem)
    {
        _presentSpawner = presentSpawner;
        _packageSystem = packageSystem;
    }

    public void SetCallData(PresentEvent callData)
    {
        _callData = callData;
        ActiveEvent();
    }

    private void ActiveEvent()
    {
        if (!_packageSystem.CheckFreeSlot())
        {
            Debug.LogError($"Not Found Free Slot");
            return;
        }

        _currentPresent = _presentSpawner.CreatePresent(_callData.IDPresent);
        _packageSystem.SetPackage(_currentPresent);
    }
}
