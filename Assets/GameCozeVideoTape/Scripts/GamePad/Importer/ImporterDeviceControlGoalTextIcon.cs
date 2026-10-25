using System;
using Zenject;

public class ImporterDeviceControlGoalTextIcon : IInitializable, IDisposable
{
    private GoalController _goalController;
    private ImporterMenuInputControlDevice _importerMenuInputControlDevice;

    public ImporterDeviceControlGoalTextIcon(GoalController goalController, ImporterMenuInputControlDevice importerMenuInputControlDevice)
    {
        _goalController = goalController;
        _importerMenuInputControlDevice = importerMenuInputControlDevice;
    }

    public void Initialize()
    {
        _importerMenuInputControlDevice.OnChangeDevice += OnChangeDevice;
    }

    public void Dispose()
    {
        _importerMenuInputControlDevice.OnChangeDevice -= OnChangeDevice;
    }

    private void OnChangeDevice(DeviceType obj)
    {
        _goalController.OnChangeDevice();
    }
}