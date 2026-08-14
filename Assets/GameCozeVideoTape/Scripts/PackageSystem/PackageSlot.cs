using UnityEngine;

public class PackageSlot : MonoBehaviour
{
    private Present _currentPresent;

    private bool _isFree => _currentPresent == null;

    public bool CheckSlot()
    {
        Debug.Log($"PackageSlot, _isFree:{_isFree}, Present:{_currentPresent}");
        // Проверяем занят ли этот слот подарком
        return _isFree;
    }

    public void SetSlot(Present currentPresent)
    {
        currentPresent.transform.position = transform.position;
        currentPresent.transform.rotation = transform.rotation;

        currentPresent.transform.SetParent(transform);

        _currentPresent = currentPresent;
        // Устанавливаем наш подарок
        // 
    }

}
