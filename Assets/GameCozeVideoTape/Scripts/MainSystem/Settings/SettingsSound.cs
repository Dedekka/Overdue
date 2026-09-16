using UnityEngine;

[CreateAssetMenu(fileName = "SettingsSound", menuName = "Create/Settings/SettingsSound")]
public class SettingsSound : ScriptableObject
{
    #region PublicField
    public string MainBusPath => _mainBusPath;
    public string EffectsBusPath => _effectsBusPath;
    public string VoiceBusPath => _voiceBusPath;
    public string MusicBusPath => _musicBusPath;

    #endregion

    [Header("BusPaths")]
    [SerializeField] private string _mainBusPath;
    [SerializeField] private string _effectsBusPath;
    [SerializeField] private string _voiceBusPath;
    [SerializeField] private string _musicBusPath;
}

