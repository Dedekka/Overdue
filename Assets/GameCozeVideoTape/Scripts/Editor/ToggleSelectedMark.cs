using TMPro;
using UnityEditor;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.PropertyVariants;
using UnityEngine.UI;

public class ToggleSelectedMark : EditorWindow
{
    [MenuItem("GameObject/Set Toggle _i")]
    public static void SetAsDebug()
    {
        GameObject selectedObject = Selection.activeGameObject as GameObject;
        if (selectedObject == null) return;

        Toggle temp_Toggle = selectedObject.GetComponent<Toggle>();
        if (temp_Toggle == null)
        {
            Debug.LogWarning("Выбранный объект не содержит Toggle");
            return;
        }
       Transform temp = temp_Toggle.transform.Find("Background");
        if (temp == null)
        {
            Debug.LogWarning("Выбранный объект не содержит Checkmark");
            return;
        }
         temp = temp.transform.Find("Checkmark");


        if (!temp.TryGetComponent<Graphic>(out Graphic graphic))
        {
            Debug.LogWarning("Выбранный объект не содержит Toggle");
            return;
        }

        temp_Toggle.graphic = graphic;
    }


    [MenuItem("GameObject/Set Localization", isValidateFunction: true)]
    public static bool SetAsDebugValidator()
    {
        return ((GameObject)Selection.activeGameObject).GetComponent<Toggle>() != null;
    }
}
