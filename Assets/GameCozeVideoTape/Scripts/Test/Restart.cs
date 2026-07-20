using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{


    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetLevel();
        }
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }
}
