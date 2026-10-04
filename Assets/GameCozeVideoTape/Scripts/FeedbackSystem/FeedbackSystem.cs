using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Zenject;

public class FeedbackSystem : IInitializable , IDisposable
{
    
    private Main_ButtonSEND _main_ButtonSEND;
    private FactoryFeedback _factoryFeedback;
 
    public FeedbackSystem(Main_ButtonSEND main_ButtonSEND , FactoryFeedback factoryFeedback)
    {
        _main_ButtonSEND = main_ButtonSEND;
        _factoryFeedback = factoryFeedback;
    }

    public void Initialize()
    {
        _main_ButtonSEND._main_ButtonSEND.onClick.AddListener(() => MainSend());
        _main_ButtonSEND._nextPage_1.onClick.AddListener(() => ControlPage(_main_ButtonSEND._titul, _main_ButtonSEND._page_1));
        _main_ButtonSEND._nextPage_2.onClick.AddListener(() => ControlPage(_main_ButtonSEND._page_1, _main_ButtonSEND._page_2));
        _main_ButtonSEND._nextPage_3.onClick.AddListener(() => ControlPage(_main_ButtonSEND._page_2, _main_ButtonSEND._page_3));
        _main_ButtonSEND._nextPage_4.onClick.AddListener(() => ControlPage(_main_ButtonSEND._page_3, _main_ButtonSEND._page_3));

    }

    private void ControlPage(GameObject pageLast, GameObject pageNext)
    {
        pageLast.SetActive(false);
        pageNext.SetActive(true);
    }

    public void Dispose()
    {
        _main_ButtonSEND._main_ButtonSEND.onClick.RemoveAllListeners();
    }

    private void MainSend()
    {
        _factoryFeedback.PrePost();
        Post().Forget();
    }

    private async UniTask Post()
    {
        WWWForm form = new WWWForm();
        form.AddField(FeedbackConstURL.Question_1_Entry, _factoryFeedback.GetFeedback(1));
        form.AddField(FeedbackConstURL.Question_2_Entry, _factoryFeedback.GetFeedback(2));
        UnityWebRequest www = UnityWebRequest.Post(FeedbackConstURL.Question_URL, form);

        await www.SendWebRequest().ToUniTask();
    }

}