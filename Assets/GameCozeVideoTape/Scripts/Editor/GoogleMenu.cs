using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class GoogleMenu
{
    #region System
    private const string SpreadSheet_id = "1E8nV_8KQ_zj8EQ3zbHRbxc3EquugKUKNG12jmPgthus";
    private const string Credentials_path = "overdue-503208-d39af501a561.json";
    #endregion

    #region Sheets Name
    private const string Items_sheets_name = "BazeCassette";
    private const string Language_sheets_name = "Language";
    private const string Genre_sheets_name = "Genre";
    private const string SubGenre_sheets_name = "SubGenre";


    private const string BazePresent_sheets_name = "BazePresent";
    private const string DialogueEvent_sheets_name = "DialogueEvent";

    private const string LanguageDialogue_sheets_name = "LanguageDialogue";


    private const string BazeDialogue_sheets_name = "BazeDialogue";

    #endregion

    private const string SettingFileName = "MainGoogleSettings";


    [MenuItem("Google/LoadGoogleSheets")]
    private static async void LoadItemsSettings()
    {
        GoogleImporter sheetsImporter = new GoogleImporter(Credentials_path, SpreadSheet_id);
        MainGoogleSettings gameSettings = LoadSettings();

        await Genre(gameSettings, sheetsImporter);
        await Item(gameSettings, sheetsImporter);
        await Dialogs(gameSettings, sheetsImporter);

        SaveSettings(gameSettings);
    }

    private static MainGoogleSettings LoadSettings()
    {
        string JsonLoader = PlayerPrefs.GetString(SettingFileName); // Здесь мы должны загружать из файла 
        MainGoogleSettings gamesettings = !string.IsNullOrEmpty(JsonLoader)
            ? JsonUtility.FromJson<MainGoogleSettings>(JsonLoader)
            : new MainGoogleSettings();
        return gamesettings;
    }

    private static void SaveSettings(MainGoogleSettings mainGoogleSettings)
    {
        string JsonSaver = JsonUtility.ToJson(mainGoogleSettings);
        PlayerPrefs.SetString(SettingFileName, JsonSaver);
        PlayerPrefs.Save();

        DataCassets dataCassets = ScriptableObject.CreateInstance<DataCassets>();
        dataCassets.Initialization(mainGoogleSettings);
        SaveAssets(PathConst.DataCassetsPath, dataCassets);

        DataLanguage dataLanguage = ScriptableObject.CreateInstance<DataLanguage>();
        dataLanguage.Initialization(mainGoogleSettings);
        SaveAssets(PathConst.LanguageCassetsPath, dataLanguage);

        DataGenre dataGenre = ScriptableObject.CreateInstance<DataGenre>();
        dataGenre.Initialization(mainGoogleSettings);
        SaveAssets(PathConst.GenrePath, dataGenre);

        DataDialogue dataDialogue = ScriptableObject.CreateInstance<DataDialogue>();
        dataDialogue.Initialization(mainGoogleSettings);
        SaveAssets(PathConst.DataDialoguePath, dataDialogue);
    }

    private static void SaveAssets(string path, ScriptableObject data)
    {
        AssetDatabase.CreateAsset(data, path);

        // 4. Сообщаем движку о необходимости обновить отображение в Project Window
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log($"Ассет создан по пути: {path}");
    }


    private static async UniTask Genre(MainGoogleSettings gameSettings, GoogleImporter sheetsImporter)
    {
        GenreParser GenreParser = new GenreParser(gameSettings);
        await sheetsImporter.DownloandAndParseSheet(Genre_sheets_name, GenreParser);

        SubGenreParser subGenreParser = new SubGenreParser(gameSettings);
        await sheetsImporter.DownloandAndParseSheet(SubGenre_sheets_name, subGenreParser);
    }

    private static async UniTask Item(MainGoogleSettings gameSettings, GoogleImporter sheetsImporter)
    {
        ItemSettingsParser ItemParser = new ItemSettingsParser(gameSettings);
        ItemLanguageParser LanguageParser = new ItemLanguageParser(gameSettings);
        await sheetsImporter.DownloandAndParseSheet(Items_sheets_name, ItemParser);
        await sheetsImporter.DownloandAndParseSheet(Language_sheets_name, LanguageParser);
    }

    private static async UniTask Dialogs(MainGoogleSettings gameSettings, GoogleImporter sheetsImporter)
    {
        PresentsParser presentsParser = new PresentsParser(gameSettings);
        await sheetsImporter.DownloandAndParseSheet(BazePresent_sheets_name, presentsParser);

        DialogueEventParser dialogueEventParser = new DialogueEventParser(gameSettings);
        await sheetsImporter.DownloandAndParseSheet(DialogueEvent_sheets_name, dialogueEventParser);

        DialogueParser dialogueParser = new DialogueParser(gameSettings);
        await sheetsImporter.DownloandAndParseSheet(BazeDialogue_sheets_name, dialogueParser);

        Debug.Log($"Dialogues: {gameSettings.Dialogues.Count}");
        for (int i = 0; i < gameSettings.Dialogues.Count; i++)
        {
            DialogSettings dialogSettings = gameSettings.Dialogues[i];
            Debug.Log($"Id: {dialogSettings.Id}, dialogSettings: {dialogSettings.DialogLines.Count}");
            for (int j = 0; j < dialogSettings.DialogLines.Count; j++)
            {
                DialogLine dialogLine = dialogSettings.DialogLines[j];
                Debug.Log($"Id: {dialogLine.IdNumber}, Character: {dialogLine.Character}, dialogLine: {dialogLine.Line}");
            }

        }
    }



}
