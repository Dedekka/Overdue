using UnityEditor;
using UnityEngine;

public class GoogleMenu
{
    private const string SpreadSheet_id = "1E8nV_8KQ_zj8EQ3zbHRbxc3EquugKUKNG12jmPgthus";
    private const string Items_sheets_mane = "BazeCassette";
    private const string Language_sheets_mane = "Language";
    private const string Credentials_path = "overdue-503208-d39af501a561.json";
    private const string SettingFileName = "MainGoogleSettings";


    private const string FilePathDataCassets = "Assets/Resources/Data/DataCassets.asset";
    private const string FilePathLanguageCassets = "Assets/Resources/Data/LanguageCassets.asset";

    [MenuItem("Google/LoadGoogleSheets")]
    private static async void LoadItemsSettings()
    {
        var sheetsImporter = new GoogleImporter(Credentials_path, SpreadSheet_id);
        var gameSettings = LoadSettings();
        var ItemParser = new ItemSettingsParser(gameSettings);
        var LanguageParser = new ItemLanguageParser(gameSettings);
        await sheetsImporter.DownloandAndParseSheet(Items_sheets_mane, ItemParser);
        await sheetsImporter.DownloandAndParseSheet(Language_sheets_mane, LanguageParser);

        //var JsonForSave = JsonUtility.ToJson(gameSettings);
        //Debug.Log(JsonForSave);

        SaveSettings(gameSettings);
    }
    
    private static MainGoogleSettings LoadSettings()
    {
        var JsonLoader = PlayerPrefs.GetString(SettingFileName); // Здесь мы должны загружать из файла 
        var gamesettings = !string.IsNullOrEmpty(JsonLoader)
            ? JsonUtility.FromJson<MainGoogleSettings>(JsonLoader)
            : new MainGoogleSettings();

        return gamesettings;
    }

    private static void SaveSettings(MainGoogleSettings mainGoogleSettings)
    {
        DataCassets dataCassets = ScriptableObject.CreateInstance<DataCassets>();
        dataCassets.Initialization(mainGoogleSettings);
        SaveAssets(FilePathDataCassets, dataCassets);

        DataLanguage dataLanguage = ScriptableObject.CreateInstance<DataLanguage>();
        dataLanguage.Initialization(mainGoogleSettings);
        SaveAssets(FilePathLanguageCassets, dataLanguage);
    }

    private static void SaveAssets(string path, ScriptableObject data)
    {
        AssetDatabase.CreateAsset(data, path);

        // 4. Сообщаем движку о необходимости обновить отображение в Project Window
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log($"Ассет создан по пути: {path}");
    }
}
