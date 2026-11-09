using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GamePadKey))]
public class EditorGamePadKey : Editor
{
    public override void OnInspectorGUI()
    {
        // Приводим target к нужному типу
        GamePadKey myTarget = (GamePadKey)target;

        DataGamePadKeyboardLanguage dataGamePadKeyboardLanguage = GetDataGamePadKeyboardLanguage();

        if (dataGamePadKeyboardLanguage == null)
        {
            Debug.LogError("Not Found DataGamePadKeyboardLanguage");
            return;
        }

        myTarget.Id = EditorGUILayout.Popup("Кнопка", myTarget.Id, dataGamePadKeyboardLanguage.GamePadKeyboardName);

        // Если нужно, можно сохранить изменения (для префабов и т.п.)
        if (GUI.changed)
        {
            EditorUtility.SetDirty(myTarget);
        }

        //Debug.LogWarning($"GamePadKey, Id:{myTarget.Id}");
    }

    private DataGamePadKeyboardLanguage GetDataGamePadKeyboardLanguage()
    {
        return AssetDatabase.LoadAssetAtPath<DataGamePadKeyboardLanguage>(PathConst.DataGamePadKeyboardLanguagePath);
    }
}
