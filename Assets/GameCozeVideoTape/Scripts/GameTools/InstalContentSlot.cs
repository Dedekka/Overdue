using UnityEngine;

public class InstalContentSlot : MonoBehaviour
{
    [SerializeField] private BazeSlot[] _shelfSlot;

    [ContextMenu("Instal")]
    public void Instal()
    {
        foreach (var slot in _shelfSlot)
        {
            slot.SetContentSlot(slot.GetComponentInChildren<ContentSlot>());
        }
    }
}