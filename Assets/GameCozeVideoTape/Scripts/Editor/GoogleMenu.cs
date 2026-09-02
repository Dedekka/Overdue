using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class GoogleMenu
{
    #region System
    private const string SpreadSheet_id = "1E8nV_8KQ_zj8EQ3zbHRbxc3EquugKUKNG12jmPgthus";
    private const string Credentials_path = "H:/_WorkProject/Overdue/KeyGoogleSheets/overdue-503208-d39af501a561.json";
    //private const string Credentials_path = "overdue-503208-d39af501a561.json";
    #endregion

    #region Sheets Name
    private const string Items_sheets_name = "BazeCassette";
    private const string Language_sheets_name = "Language";
    private const string Genre_sheets_name = "Genre";
    private const string SubGenre_sheets_name = "SubGenre";
    private const string Present_sheets_name = "BazePresent";
    private const string DialogueEvent_sheets_name = "DialogueEvent";
    private const string BazeDialogue_sheets_name = "BazeDialogue";
    private const string CassetteOpera_sheets_name = "CassetteOpera";
    private const string MusicCassette_sheets_name = "BazeMusicCassette";
    //private const string LanguageDialogue_sheets_name = "LanguageDialogue";




    #endregion

    //private const string SettingFileName = "MainGoogleSettings";


    [MenuItem("Google/LoadGoogleSheets")]
    private static async void LoadItemsSettings()
    {
        GoogleImporter sheetsImporter = new GoogleImporter(Credentials_path, SpreadSheet_id);
        MainGoogleSettings gameSettings = new MainGoogleSettings();

        await Genre(gameSettings, sheetsImporter);
        await Item(gameSettings, sheetsImporter);
        await Dialogs(gameSettings, sheetsImporter);
        await Opera(gameSettings, sheetsImporter);
        await MusicCassette(gameSettings, sheetsImporter);
       
        SaveSettings(gameSettings);
    }

    //private static MainGoogleSettings LoadSettings()
    //{
    //    string JsonLoader = PlayerPrefs.GetString(SettingFileName); // Здесь мы должны загружать из файла 
    //    MainGoogleSettings gamesettings = !string.IsNullOrEmpty(JsonLoader)
    //        ? JsonUtility.FromJson<MainGoogleSettings>(JsonLoader)
    //        : new MainGoogleSettings();
    //    return gamesettings;
    //}

    private static void SaveSettings(MainGoogleSettings mainGoogleSettings)
    {
        //string JsonSaver = JsonUtility.ToJson(mainGoogleSettings);
        //PlayerPrefs.SetString(SettingFileName, JsonSaver);
        //PlayerPrefs.Save();

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

        DataPresent dataPresent = ScriptableObject.CreateInstance<DataPresent>();
        dataPresent.Initialization(mainGoogleSettings);
        SaveAssets(PathConst.DataPresentPath, dataPresent);

        DataOpera dataOpera = ScriptableObject.CreateInstance<DataOpera>();
        dataOpera.Initialization(mainGoogleSettings);
        SaveAssets(PathConst.DataOperaPath, dataOpera);

        DataMusicCassets dataMusicCassets = ScriptableObject.CreateInstance<DataMusicCassets>();
        dataMusicCassets.Initialization(mainGoogleSettings);
        SaveAssets(PathConst.DataMusicCassetsPath, dataMusicCassets);
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
        await sheetsImporter.DownloandAndParseSheet(Present_sheets_name, presentsParser);

        DialogueEventParser dialogueEventParser = new DialogueEventParser(gameSettings);
        await sheetsImporter.DownloandAndParseSheet(DialogueEvent_sheets_name, dialogueEventParser);

        DialogueParser dialogueParser = new DialogueParser(gameSettings);
        await sheetsImporter.DownloandAndParseSheet(BazeDialogue_sheets_name, dialogueParser);
    }

    private static async UniTask Opera(MainGoogleSettings gameSettings, GoogleImporter sheetsImporter)
    {
        OperaParser operaParser = new OperaParser(gameSettings);
        await sheetsImporter.DownloandAndParseSheet(CassetteOpera_sheets_name, operaParser);
    }

    private static async UniTask MusicCassette(MainGoogleSettings gameSettings, GoogleImporter sheetsImporter)
    {
        MusicCassetteParser musicCassetteParser = new MusicCassetteParser(gameSettings);
        await sheetsImporter.DownloandAndParseSheet(MusicCassette_sheets_name, musicCassetteParser);
    }
}