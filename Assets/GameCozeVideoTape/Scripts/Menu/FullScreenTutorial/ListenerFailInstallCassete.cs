using System;

public class ListenerFailInstallCassete : IDisposable
{
    private ManagerRack _managerRack;
    public event Action OnComplited;

    public ListenerFailInstallCassete(ManagerRack managerRack)
    {
        _managerRack = managerRack;
    }

    public void Dispose()
    {
        SetUnSub();
    }

    public void Initialize()
    {
        SetSub();
    }

    private void SetSub()
    {
        for (int i = 0; i < _managerRack.Racks.Count; i++)
        {
            _managerRack.Racks[i].OnInstallState += FailInstall;
        }
    }

    private void SetUnSub()
    {
        for (int i = 0; i < _managerRack.Racks.Count; i++)
        {
            _managerRack.Racks[i].OnInstallState -= FailInstall;
        }
    }

    private void FailInstall(bool isState)
    {
        if (isState) { return; }
        Dispose();
        OnComplited?.Invoke();
    }
}