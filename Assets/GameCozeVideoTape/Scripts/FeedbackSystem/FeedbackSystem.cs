using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

public class FeedbackSystem : IInitializable, IDisposable
{

    private CancellationTokenSource _cancellationTokenSource;
    private Main_ButtonSEND _main_ButtonSEND;
    private FactoryFeedback _factoryFeedback;
    private ControlLogic _сontrolLogic;
    private ControlSettings _controlSettings;

    public FeedbackSystem(Main_ButtonSEND main_ButtonSEND, FactoryFeedback factoryFeedback, ControlLogic сontrolLogic, ControlSettings controlSettings)
    {
        _main_ButtonSEND = main_ButtonSEND;
        _factoryFeedback = factoryFeedback;
        _сontrolLogic = сontrolLogic;
        _controlSettings = controlSettings;
    }

    public void Initialize()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _main_ButtonSEND._main_ButtonSEND.onClick.AddListener(() => MainSend());


        _main_ButtonSEND._pageButtons[0].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[0].LastPage, _main_ButtonSEND._pageButtons[1].LastPage));
        _main_ButtonSEND._pageButtons[1].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[1].LastPage, _main_ButtonSEND._pageButtons[2].LastPage));
        _main_ButtonSEND._pageButtons[2].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[2].LastPage, _main_ButtonSEND._pageButtons[3].LastPage));
        _main_ButtonSEND._pageButtons[3].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[3].LastPage, _main_ButtonSEND._pageButtons[4].LastPage));
        _main_ButtonSEND._pageButtons[4].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[4].LastPage, _main_ButtonSEND._pageButtons[5].LastPage));
        _main_ButtonSEND._pageButtons[5].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[5].LastPage, _main_ButtonSEND._pageButtons[6].LastPage));
        _main_ButtonSEND._pageButtons[6].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[6].LastPage, _main_ButtonSEND._pageButtons[7].LastPage));
        _main_ButtonSEND._pageButtons[7].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[7].LastPage, _main_ButtonSEND._pageButtons[8].LastPage));
        _main_ButtonSEND._pageButtons[8].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[8].LastPage, _main_ButtonSEND._pageButtons[9].LastPage));
        _main_ButtonSEND._pageButtons[9].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[9].LastPage, _main_ButtonSEND._pageButtons[10].LastPage));
        _main_ButtonSEND._pageButtons[10].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[10].LastPage, _main_ButtonSEND._pageButtons[11].LastPage));
        _main_ButtonSEND._pageButtons[11].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[11].LastPage, _main_ButtonSEND._pageButtons[12].LastPage));
        _main_ButtonSEND._pageButtons[12].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[12].LastPage, _main_ButtonSEND._pageButtons[13].LastPage));
        _main_ButtonSEND._pageButtons[13].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[13].LastPage, _main_ButtonSEND._pageButtons[14].LastPage));
        _main_ButtonSEND._pageButtons[14].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[14].LastPage, _main_ButtonSEND._pageButtons[15].LastPage));
        _main_ButtonSEND._pageButtons[15].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[15].LastPage, _main_ButtonSEND._pageButtons[16].LastPage));
        _main_ButtonSEND._pageButtons[16].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[16].LastPage, _main_ButtonSEND._pageButtons[17].LastPage));
        _main_ButtonSEND._pageButtons[17].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[17].LastPage, _main_ButtonSEND._pageButtons[18].LastPage));
        _main_ButtonSEND._pageButtons[18].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[18].LastPage, _main_ButtonSEND._pageButtons[19].LastPage));
        _main_ButtonSEND._pageButtons[19].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[19].LastPage, _main_ButtonSEND._pageButtons[20].LastPage));
        _main_ButtonSEND._pageButtons[20].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[20].LastPage, _main_ButtonSEND._pageButtons[21].LastPage));
        _main_ButtonSEND._pageButtons[21].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[21].LastPage, _main_ButtonSEND._pageButtons[22].LastPage));
        _main_ButtonSEND._pageButtons[22].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[22].LastPage, _main_ButtonSEND._pageButtons[23].LastPage));
        _main_ButtonSEND._pageButtons[23].NextPage.onClick.AddListener(() => ControlPage(_main_ButtonSEND._pageButtons[23].LastPage, _main_ButtonSEND._pageButtons[0].LastPage));

    }

    private void ControlPage(GameObject pageLast, GameObject pageNext)
    {
        pageLast.SetActive(false);
        pageNext.SetActive(true);
    }

    public void Dispose()
    {
        _main_ButtonSEND._main_ButtonSEND.onClick.RemoveAllListeners();
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
    }

    private async void MainSend()
    {
        _factoryFeedback.PrePost();
        await Post(_cancellationTokenSource.Token);
        _controlSettings.ChangeComplitedFeedback(true);
        _сontrolLogic.BackMenu();
    }

    private async UniTask Post(CancellationToken cancellationToken)
    {
        try
        {
            WWWForm form = new WWWForm();
            form.AddField(FeedbackConstURL.Question_1_Entry, _factoryFeedback.GetFeedback(1));
            form.AddField(FeedbackConstURL.Question_2_Entry, _factoryFeedback.GetFeedback(2));
            form.AddField(FeedbackConstURL.Question_3_Entry, _factoryFeedback.GetFeedback(3));
            form.AddField(FeedbackConstURL.Question_4_Entry, _factoryFeedback.GetFeedback(4));
            form.AddField(FeedbackConstURL.Question_5_Entry, _factoryFeedback.GetFeedback(5));
            form.AddField(FeedbackConstURL.Question_6_Entry, _factoryFeedback.GetFeedback(6));
            form.AddField(FeedbackConstURL.Question_7_Entry, _factoryFeedback.GetFeedback(7));
            form.AddField(FeedbackConstURL.Question_8_Entry, _factoryFeedback.GetFeedback(8));
            form.AddField(FeedbackConstURL.Question_9_Entry, _factoryFeedback.GetFeedback(9));
            form.AddField(FeedbackConstURL.Question_10_Entry, _factoryFeedback.GetFeedback(10));
            form.AddField(FeedbackConstURL.Question_11_Entry, _factoryFeedback.GetFeedback(11));
            form.AddField(FeedbackConstURL.Question_12_Entry, _factoryFeedback.GetFeedback(12));
            form.AddField(FeedbackConstURL.Question_13_Entry, _factoryFeedback.GetFeedback(13));
            form.AddField(FeedbackConstURL.Question_14_Entry, _factoryFeedback.GetFeedback(14));
            form.AddField(FeedbackConstURL.Question_15_Entry, _factoryFeedback.GetFeedback(15));
            form.AddField(FeedbackConstURL.Question_16_Entry, _factoryFeedback.GetFeedback(16));
            form.AddField(FeedbackConstURL.Question_17_Entry, _factoryFeedback.GetFeedback(17));
            form.AddField(FeedbackConstURL.Question_18_Entry, _factoryFeedback.GetFeedback(18));
            form.AddField(FeedbackConstURL.Question_19_Entry, _factoryFeedback.GetFeedback(19));
            form.AddField(FeedbackConstURL.Question_20_Entry, _factoryFeedback.GetFeedback(20));
            form.AddField(FeedbackConstURL.Question_21_Entry, _factoryFeedback.GetFeedback(21));
            form.AddField(FeedbackConstURL.Question_22_Entry, _factoryFeedback.GetFeedback(22));
            form.AddField(FeedbackConstURL.Question_23_Entry, _factoryFeedback.GetFeedback(23));

            using (UnityWebRequest www = UnityWebRequest.Post(FeedbackConstURL.Question_URL, form))
            {
                www.timeout = 5;
                Debug.Log($"SendWebRequest: {FeedbackConstURL.Question_URL}");
                await www.SendWebRequest()
                    .ToUniTask(cancellationToken: cancellationToken);


                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogWarning($"HTTP error: {www.responseCode} — {www.error}");
                }
            }
        }
        catch (UnityWebRequestException ex)
        {
            // Здесь можно проверить ex.Result, ex.Error и решить, что делать
            Debug.LogWarning($"Network error: {ex.Error}");
        }
        catch (OperationCanceledException)
        {
            Debug.LogWarning($"Задача была отменена");
            // Задача была отменена, всё ок
        }
    }

}