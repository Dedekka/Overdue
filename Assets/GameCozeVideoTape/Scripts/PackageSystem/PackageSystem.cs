using System.Collections.Generic;
using UnityEngine;

public class PackageSystem : MonoBehaviour
{
    [SerializeField] private List<PackageSlot> _packageSlot;

    // У тебя есть список слотов 

    public void SetPackage(Present currentPresent)
    {
        for (int i = 0; i < _packageSlot.Count; i++)
        {
            PackageSlot slot = _packageSlot[i];
            // Проверяем занят ли этот слот подарком
            Debug.Log($"PackageSystem, ID:{i}, Free:{slot.CheckSlot()}");
            if (slot.CheckSlot())
            {
                SetSlot(slot, currentPresent);
                break;
            }
        }
    }

    public bool CheckFreeSlot()
    {
        bool freeSlot = false;
        for (int i = 0; i < _packageSlot.Count; i++)
        {
            PackageSlot slot = _packageSlot[i];
            // Проверяем занят ли этот слот подарком
            Debug.Log($"PackageSystem, ID:{i}, Free:{slot.CheckSlot()}");
            if (slot.CheckSlot())
            {
                freeSlot = true;
                break;
            }
        }
        return freeSlot;
    }

    private void SetSlot(PackageSlot slot, Present currentPresent)
    {
        slot.SetSlot(currentPresent);
        // Устанавливаем наш подарок
        // 
    }

}
