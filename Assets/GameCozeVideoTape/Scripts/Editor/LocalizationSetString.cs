using TMPro;
using UnityEditor;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.PropertyVariants;

public class LocalizationSetString : EditorWindow
{
    [MenuItem("GameObject/Set Localization _a")]
    public static void SetAsDebug()
    {
        GameObject selectedObject = Selection.activeGameObject as GameObject;
        if (selectedObject == null) return;

        TextMeshProUGUI tmpText = selectedObject.GetComponent<TextMeshProUGUI>();
        if (tmpText == null)
        {
            Debug.LogWarning("Выбранный объект не содержит TMP_Text");
            return;
        }

        if (selectedObject.TryGetComponent<GameObjectLocalizer>(out var oldLocalizer))
        {
            DestroyImmediate(oldLocalizer);
        }

        if (!selectedObject.TryGetComponent<LocalizeStringEvent>(out var localizeString))
        {
            localizeString = selectedObject.AddComponent<LocalizeStringEvent>();
        }

        localizeString.OnUpdateString.RemoveAllListeners();

        UnityAction<string> updateAction = new UnityAction<string>((string value) =>
        {
            tmpText.text = value;
        });

        localizeString.OnUpdateString.AddListener(updateAction);

        UnityEventTools.AddPersistentListener(
          localizeString.OnUpdateString,
          new UnityAction<string>(tmpText.SetText)
        );

        EditorUtility.SetDirty(selectedObject);

        if (!string.IsNullOrEmpty(localizeString.StringReference.TableReference))
        {
            localizeString.RefreshString();
        }
        Debug.Log($"Локализация настроена для: {selectedObject.name}");
    }


    [MenuItem("GameObject/Set Localization", isValidateFunction: true)]
    public static bool SetAsDebugValidator()
    {
        return ((GameObject)Selection.activeGameObject).GetComponent<TextMeshProUGUI>() != null;
    }
}
