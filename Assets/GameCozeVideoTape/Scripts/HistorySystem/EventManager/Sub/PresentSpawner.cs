using UnityEngine;

public class PresentSpawner 
{
    private FactoryPresent _factoryPresent;

    public PresentSpawner (FactoryPresent factoryPresent)
    {
        _factoryPresent = factoryPresent;
    }

    public Present CreatePresent(int id)
    {
        return _factoryPresent.GetPresent(id);
        // Фабрика создает новый объект
    }

}
