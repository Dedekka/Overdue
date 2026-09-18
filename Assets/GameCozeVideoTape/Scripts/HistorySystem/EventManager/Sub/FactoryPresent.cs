using UnityEngine;
using Zenject;

public class FactoryPresent
{
    private ViewRenderer _viewRenderer;
    private DataPresent _dataPresent;
    private DataPresentLanguage _dataPresentLanguage;
    private Present _prefabPresent;
    private Material _material;
    private DiContainer _container;
    private Player _player;

    private Language _currentLanguage;
    private ControlSettings _controlSettings;

    public FactoryPresent(Present prefabPresent, DataPresent dataPresent, ViewRenderer viewRenderer, Material material, DiContainer container, Player player, DataPresentLanguage dataPresentLanguage, ControlSettings controlSettings)
    {
        _prefabPresent = prefabPresent;
        _dataPresent = dataPresent;
        _viewRenderer = viewRenderer;
        _material = material;
        _container = container;
        _player = player;
        _dataPresentLanguage = dataPresentLanguage;
        _controlSettings = controlSettings;
    }

    public Present GetPresent(int id)
    {
        Present tempPresent = _container.InstantiatePrefabForComponent<Present>(_prefabPresent, Vector3.zero, Quaternion.identity, null);

        PresentSettings tempPresentSettings = _dataPresent.GetPresentSettings(id);
        _currentLanguage = _controlSettings.Language;
        string currentNamePresent = _dataPresentLanguage.GetItem(id).GetLanguage(_currentLanguage);

        tempPresent.SetPresentSettings(tempPresentSettings, currentNamePresent);
        //_viewRenderer.Initialization(_material, tempPresent.gameObject, tempPresentSettings.MaterialIndex);
        Physics.IgnoreCollision(tempPresent.Collider, _player.CharacterController);
        return tempPresent;
    }
}