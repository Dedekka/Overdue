using UnityEngine;
using UnityEngine.InputSystem;

public class TestVibration : MonoBehaviour
{
    [ContextMenu("Active")]
   private void Set()
    {
        if(Gamepad.current == null) { return; }

        Gamepad.current.SetMotorSpeeds(0.123f, 0.234f);
    }
}
