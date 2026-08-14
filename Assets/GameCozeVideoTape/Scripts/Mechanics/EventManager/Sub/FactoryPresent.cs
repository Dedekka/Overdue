using UnityEngine;
using Zenject;

public class FactoryPresent
{
    private ViewRenderer _viewRenderer;
    private DataPresent _dataPresent;
    private Present _prefabPresent;
    private Material _material;
    private DiContainer _container;
    private Player _player;

    public FactoryPresent(Present prefabPresent, DataPresent dataPresent, ViewRenderer viewRenderer, Material material, DiContainer container, Player player)
    {
        _prefabPresent = prefabPresent;
        _dataPresent = dataPresent;
        _viewRenderer = viewRenderer;
        _material = material;
        _container = container;
        _player = player;
    }

    public Present GetPresent(int id)
    {
        Present tempPresent = _container.InstantiatePrefabForComponent<Present>(_prefabPresent, Vector3.zero, Quaternion.identity, null);
       
        PresentSettings tempPresentSettings = _dataPresent.GetPresentSettings(id);
        tempPresent.SetPresentSettings(tempPresentSettings);
        _viewRenderer.Initialization(_material, tempPresent.gameObject, tempPresentSettings.MaterialIndex);
        Physics.IgnoreCollision(tempPresent.Collider, _player.CharacterController);
        return tempPresent;
    }
}