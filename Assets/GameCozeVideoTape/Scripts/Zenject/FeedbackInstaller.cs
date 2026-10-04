using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FeedbackInstaller : MonoInstaller
{
    [Header("Main")]
    [SerializeField] private GameObject Titul;
    [SerializeField] private Button Main_ButtonSEND;
    [SerializeField] private Button _nextPage_1;
    [SerializeField] private Button _nextPage_2;
    [SerializeField] private Button _nextPage_3;
    [SerializeField] private Button _nextPage_4;

    [Header("Question_1")] // несколько вариантов
    [SerializeField] private GameObject Page_1;
    [SerializeField] private Toggle Question_1_Toggle_1;
    [SerializeField] private Toggle Question_1_Toggle_2;
    [SerializeField] private Toggle Question_1_Toggle_3;
    [SerializeField] private Toggle Question_1_Toggle_4;
    [SerializeField] private Toggle Question_1_Toggle_5;
    [SerializeField] private Toggle Question_1_Toggle_6;
    [SerializeField] private Toggle Question_1_Toggle_7;
    [SerializeField] private Toggle Question_1_Toggle_8;
    [SerializeField] private Toggle Question_1_Toggle_9;
    [SerializeField] private Toggle Question_1_Toggle_10;

    [Header("Question_2")]  // 1 вариант
    [SerializeField] private GameObject Page_2;
    [SerializeField] private Toggle Question_2_Toggle_1;
    [SerializeField] private Toggle Question_2_Toggle_2;
    [SerializeField] private Toggle Question_2_Toggle_3;
    [SerializeField] private Toggle Question_2_Toggle_4;
    [SerializeField] private Toggle Question_2_Toggle_5;

    [Header("Question_3")] // несколько вариант + описание
    [SerializeField] private GameObject Page_3;
    [SerializeField] private Toggle Question_3_Toggle_1;
    [SerializeField] private Toggle Question_3_Toggle_2;
    [SerializeField] private Toggle Question_3_Toggle_3;
    [SerializeField] private Toggle Question_3_Toggle_4;
    [SerializeField] private Toggle Question_3_Toggle_5;
    [SerializeField] private Toggle Question_3_Toggle_6;
    [SerializeField] private Toggle Question_3_Toggle_7;
    [SerializeField] private TMP_InputField Question_3_InputField_1;

    public override void InstallBindings()
    {
        BindQuestions();
        BindMain();
    }

    private void BindMain()
    {
        Container.Bind<FactoryFeedback>()
            .AsSingle();


        Container.BindInterfacesAndSelfTo<FeedbackSystem>()
             .AsSingle()
             .WithArguments(
            new Main_ButtonSEND(
                Main_ButtonSEND,
                    _nextPage_1,
                    _nextPage_2,
                    _nextPage_3,
                    _nextPage_4,
                    Titul,
                    Page_1,
                    Page_2,
                    Page_3
                    ));
    }

    private void BindQuestions()
    {
        Container.BindInterfacesAndSelfTo<Question_1>()
             .AsSingle()
             .WithArguments
             (1,
             new DataQuestion_1
                 (
        Question_1_Toggle_1,
        Question_1_Toggle_2,
        Question_1_Toggle_3,
        Question_1_Toggle_4,
        Question_1_Toggle_5,
        Question_1_Toggle_6,
        Question_1_Toggle_7,
        Question_1_Toggle_8,
        Question_1_Toggle_9,
        Question_1_Toggle_10));


        Container.BindInterfacesAndSelfTo<Question_2>()
            .AsSingle()
            .WithArguments
            (2,
            new DataQuestion_2
                (
       Question_2_Toggle_1,
       Question_2_Toggle_2,
       Question_2_Toggle_3,
       Question_2_Toggle_4,
       Question_2_Toggle_5));

        Container.BindInterfacesAndSelfTo<Question_3>()
           .AsSingle()
           .WithArguments
           (3,
            new DataQuestion_3
            (
                Question_3_Toggle_1,
                Question_3_Toggle_2,
                Question_3_Toggle_3,
                Question_3_Toggle_4,
                Question_3_Toggle_5,
                Question_3_Toggle_6,
                Question_3_Toggle_7,
                Question_3_InputField_1
                ));
    }
}

public class Main_ButtonSEND
{
    public Button _main_ButtonSEND;
    [Header("Button")]
    public Button _nextPage_1;
    public Button _nextPage_2;
    public Button _nextPage_3;
    public Button _nextPage_4;
    [Header("Page")]
    public GameObject _titul;
    public GameObject _page_1;
    public GameObject _page_2;
    public GameObject _page_3;

    public Main_ButtonSEND
        (
     Button Main_ButtonSEND,
     Button _nextPage_1,
     Button _nextPage_2,
     Button _nextPage_3,
     Button _nextPage_4,

     GameObject _page_1,
     GameObject _page_2,
     GameObject _page_3,
     GameObject _page_4
        )
    {
        _main_ButtonSEND = Main_ButtonSEND;
        this._nextPage_1 = _nextPage_1;
        this._nextPage_2 = _nextPage_2;
        this._nextPage_3 = _nextPage_3;
        this._nextPage_4 = _nextPage_4;
        this._page_1 = _page_1;
        this._page_1 = _page_2;
        this._page_2 = _page_3;
        this._page_3 = _page_4;
    }
}




public class DataQuestion_2
{
    public Toggle Question_2_Toggle_1;
    public Toggle Question_2_Toggle_2;
    public Toggle Question_2_Toggle_3;
    public Toggle Question_2_Toggle_4;
    public Toggle Question_2_Toggle_5;

    public DataQuestion_2
        (
    Toggle Question_2_Toggle_1,
    Toggle Question_2_Toggle_2,
    Toggle Question_2_Toggle_3,
    Toggle Question_2_Toggle_4,
    Toggle Question_2_Toggle_5
        )
    {
        this.Question_2_Toggle_1 = Question_2_Toggle_1;
        this.Question_2_Toggle_2 = Question_2_Toggle_2;
        this.Question_2_Toggle_3 = Question_2_Toggle_3;
        this.Question_2_Toggle_4 = Question_2_Toggle_4;
        this.Question_2_Toggle_5 = Question_2_Toggle_5;

    }
}