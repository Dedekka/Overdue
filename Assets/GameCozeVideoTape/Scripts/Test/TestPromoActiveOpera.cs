using UnityEngine;
using UnityEngine.InputSystem;

public class TestPromoActiveOpera : MonoBehaviour
{
    [SerializeField] private TV _tv;
    [SerializeField] private CassetteObject _cassetteObject;
    [SerializeField] private Transform _posCasset;

    private void Update()
    {
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            TeleportedOpera();
        }
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            ActiveOpera();
        }
    }

    private void TeleportedOpera()
    {
        _cassetteObject.transform.position = _posCasset.position;
        _cassetteObject.transform.forward = _posCasset.forward;
    }

    private void ActiveOpera()
    {
        _tv.TESTPROMOOnPlayCasset(_cassetteObject);
    }
}
