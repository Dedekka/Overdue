using UnityEngine;

[CreateAssetMenu(fileName = "SettingRack", menuName = "Create/Settings/Rack")]
public class SettingRack : ScriptableObject
{
    [SerializeField] private Genre _genre;
}
