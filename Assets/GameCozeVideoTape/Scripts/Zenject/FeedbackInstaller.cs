using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FeedbackInstaller : MonoInstaller
{
    [Header("Main")]

    [SerializeField] private List<PageButton> _pageButtons;

    [SerializeField] private Button Main_ButtonSEND;

    [Header("Question_1")] // несколько вариантов
    [SerializeField] private PageMultyChoose Page_1;

    [Header("Question_2")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_2;

    [Header("Question_3")] // несколько вариант + описание
    [SerializeField] private PageMultyChoose Page_3;
    [SerializeField] private TMP_InputField Question_3_InputField_1;

    [Header("Question_4")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_4;

    [Header("Question_5")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_5;

    [Header("Question_6")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_6;

    [Header("Question_7")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_7;

    [Header("Question_8")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_8;

    [Header("Question_9")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_9;

    [Header("Question_10")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_10;

    [Header("Question_11")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_11;

    [Header("Question_12")]  // 1 вариант
    [SerializeField] private PageMultyChoose Page_12;
    [SerializeField] private TMP_InputField Question_12_InputField_1;

    [Header("Question_13")]  // 1 вариант
    [SerializeField] private PageMultyChoose Page_13;
    [SerializeField] private TMP_InputField Question_13_InputField_1;

    [Header("Question_14")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_14;

    [Header("Question_15")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_15;

    [Header("Question_16")]  // 1 вариант
    [SerializeField] private TMP_InputField Question_16_InputField_1;

    [Header("Question_17")]  // 1 вариант
    [SerializeField] private TMP_InputField Question_17_InputField_1;

    [Header("Question_18")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_18;

    [Header("Question_19")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_19;

    [Header("Question_20")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_20;

    [Header("Question_21")]  // 1 вариант
    [SerializeField] private PageOneChoose Page_21;

    [Header("Question_22")]  // 1 вариант
    //[SerializeField] private PageOneChoose Page_22;
    [SerializeField] private TMP_InputField Question_22_InputField_1;

    [Header("Question_23")]  // 1 вариант
    [SerializeField] private PageMultyChoose Page_23;
    [SerializeField] private TMP_InputField Question_23_InputField_1;

    public override void InstallBindings()
    {
        BindSub();
        BindQuestions();
        BindMain();
    }

    private void BindSub()
    {
       
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
                _pageButtons
                    ));
    }

    private void BindQuestions()
    {
        Container.BindInterfacesAndSelfTo<Question_1>()
             .AsSingle()
             .WithArguments(1, Page_1, new List<SendSring>()
             {
             new SendSring(1,"Как подбирать и ставить кассеты"),
             new SendSring(2,"Как переключаться между кассетами в руках"),
             new SendSring(3,"Как определить нужную полку по жанру и поджанру"),
             new SendSring(4,"Как использовать обложку, название и стикер как подсказки"),
             new SendSring(5,"Как пользоваться видеомагнитофоном"),
             new SendSring(6,"Как отвечать на телефон"),
             new SendSring(7,"Где искать возвращённые клиентами кассеты"),
             new SendSring(8,"Как размещать подарки"),
             new SendSring(9,"Как менять музыку"),
             new SendSring(10,"Обучение в целом было непонятным"),
             });

        Container.BindInterfacesAndSelfTo<Question_2>()
                .AsSingle()
                .WithArguments(2, Page_2, new List<SendSring>()
                 {
             new SendSring(1,"Почти всегда понимал(а) сразу"),
             new SendSring(2,"Обычно понимал(а) после изучения обложки"),
             new SendSring(3,"Иногда приходилось долго разбираться"),
             new SendSring(4,"Часто приходилось угадывать"),
             new SendSring(5,"Почти никогда не понимал(а), куда её ставить"),
                 });

        Container.BindInterfacesAndSelfTo<Question_3>()
           .AsSingle()
           .WithArguments(3, Page_3, Question_3_InputField_1, new List<SendSring>()
             {
             new SendSring(1,"Иллюстрация на обложке"),
             new SendSring(2,"Цветовая гамма"),
             new SendSring(3,"Название фильма"),
             new SendSring(4,"Стикер на кассете"),
             new SendSring(5,"Уже расставленные рядом фильмы"),
             new SendSring(6,"Просмотр кассеты на видеомагнитофоне"),
             new SendSring(7,"Просто пробовал(а) разные полки"),
             });

        Container.BindInterfacesAndSelfTo<Question_4>()
           .AsSingle()
           .WithArguments(4, Page_4, new List<SendSring>()
             {
             new SendSring(1,"Хочу, чтобы было заметно проще"),
             new SendSring(2,"Можно сделать немного проще"),
             new SendSring(3,"Сейчас в самый раз"),
             new SendSring(4,"Можно сделать немного сложнее"),
             new SendSring(5,"Хочу больше неоднозначных кассет и загадок"),
             });


        Container.BindInterfacesAndSelfTo<Question_5>()
           .AsSingle()
           .WithArguments(5, Page_5, new List<SendSring>()
             {
             new SendSring(1,"Совсем не понравилось"),
             new SendSring(2,"Скорее не понравилось"),
             new SendSring(3,"Нормально"),
             new SendSring(4,"Понравилось"),
             new SendSring(5,"Очень понравилось"),
             });


        Container.BindInterfacesAndSelfTo<Question_6>()
           .AsSingle()
           .WithArguments(6, Page_6, new List<SendSring>()
             {
             new SendSring(1,"Да, очень"),
             new SendSring(2,"Скорее да"),
             new SendSring(3,"Не уверен(а)"),
             new SendSring(4,"Скорее нет"),
             new SendSring(5,"Нет"),
             });

        Container.BindInterfacesAndSelfTo<Question_7>()
           .AsSingle()
           .WithArguments(7, Page_7, new List<SendSring>()
             {
             new SendSring(1,"Да"),
             new SendSring(2,"Нет"),
             new SendSring(3,"Не заметил(а), что так можно"),
             new SendSring(4,"Понял(а), что так можно, но не было необходимости"),
             });


        Container.BindInterfacesAndSelfTo<Question_8>()
           .AsSingle()
           .WithArguments(8, Page_8, new List<SendSring>()
             {
             new SendSring(1,"Да, хотелось смотреть даже без необходимости"),
             new SendSring(2,"Да, как игровая механика это работает"),
             new SendSring(3,"Нейтрально"),
             new SendSring(4,"Скорее отвлекало от сортировки"),
             new SendSring(5,"Вообще не хотелось этим пользоваться"),
             });

        Container.BindInterfacesAndSelfTo<Question_9>()
           .AsSingle()
           .WithArguments(9, Page_9, new List<SendSring>()
             {
             new SendSring(1,"Всё было понятно"),
             new SendSring(2,"Понял(а) не сразу, но потом разобрался(ась)"),
             new SendSring(3,"Было непонятно, где искать кассету"),
             new SendSring(4,"Было непонятно, что делать с подарком"),
             new SendSring(5,"В целом не понял(а), зачем нужны звонки"),
             });

        Container.BindInterfacesAndSelfTo<Question_10>()
           .AsSingle()
           .WithArguments(10, Page_10, new List<SendSring>()
             {
             new SendSring(1,"Совсем не интересны — хотелось быстрее вернуться к сортировке"),
             new SendSring(2,"Скорее не интересны"),
             new SendSring(3,"Нормально"),
             new SendSring(4,"Интересны"),
             new SendSring(5,"Очень интересны — хотелось бы больше таких историй"),
             });

        Container.BindInterfacesAndSelfTo<Question_11>()
           .AsSingle()
           .WithArguments(11, Page_11, new List<SendSring>()
             {
             new SendSring(1,"Чаще"),
             new SendSring(2,"Немного чаще"),
             new SendSring(3,"Сейчас в самый раз"),
             new SendSring(4,"Немного реже"),
             new SendSring(5,"Значительно реже"),
             });

        Container.BindInterfacesAndSelfTo<Question_12>()
           .AsSingle()
           .WithArguments(12, Page_12, Question_12_InputField_1, new List<SendSring>()
             {
             new SendSring(1,"Больше подарков и украшения магазина"),
             new SendSring(2,"Больше кассет, которые можно посмотреть на VCR"),
             new SendSring(3,"Больше звонков и историй клиентов"),
             new SendSring(4,"Больше серий Sunset Creek"),
             new SendSring(5,"Больше аудиокассет и музыки"),
             new SendSring(6,"Больше взаимодействий с Луи"),
             new SendSring(7,"Больше необычных / сложных кассет для сортировки"),
             new SendSring(8,"Ничего из этого — мне достаточно самой сортировки"),
             });

        Container.BindInterfacesAndSelfTo<Question_13>()
           .AsSingle()
           .WithArguments(13, Page_13, Question_13_InputField_1, new List<SendSring>()
             {
             new SendSring(1,"Уютная"),
             new SendSring(2,"Ностальгическая"),
             new SendSring(3,"Расслабляющая"),
             new SendSring(4,"Забавная"),
             new SendSring(5,"Немного странная"),
             new SendSring(6,"Медитативная"),
             new SendSring(7,"Хаотичная"),
             new SendSring(8,"Не почувствовал(а) особой атмосферы"),
             });

        Container.BindInterfacesAndSelfTo<Question_14>()
           .AsSingle()
           .WithArguments(14, Page_14, new List<SendSring>()
             {
             new SendSring(1,"Очень понравился"),
             new SendSring(2,"Скорее понравился"),
             new SendSring(3,"Нейтрально"),
             new SendSring(4,"Скорее не понравился"),
             new SendSring(5,"Совсем не понравился"),
             });

        Container.BindInterfacesAndSelfTo<Question_15>()
           .AsSingle()
           .WithArguments(15, Page_15, new List<SendSring>()
             {
             new SendSring(1,"Слишком медленным"),
             new SendSring(2,"Скорее медленным"),
             new SendSring(3,"В самый раз"),
             new SendSring(4,"Скорее быстрым"),
             new SendSring(5,"Слишком быстрым"),
             });

        Container.BindInterfacesAndSelfTo<Question_16>()
           .AsSingle()
           .WithArguments(16, Question_16_InputField_1);

        Container.BindInterfacesAndSelfTo<Question_17>()
           .AsSingle()
           .WithArguments(17, Question_17_InputField_1);

        Container.BindInterfacesAndSelfTo<Question_18>()
           .AsSingle()
           .WithArguments(18, Page_18, new List<SendSring>()
             {
             new SendSring(1,"Точно не порекомендую"),
             new SendSring(2,"Скорее не порекомендую"),
             new SendSring(3,"Не уверен(а)"),
             new SendSring(4,"Скорее порекомендую"),
             new SendSring(5,"Точно порекомендую"),
             });

        Container.BindInterfacesAndSelfTo<Question_19>()
           .AsSingle()
           .WithArguments(19, Page_19, new List<SendSring>()
             {
             new SendSring(1,"Да, точно"),
             new SendSring(2,"Скорее да"),
             new SendSring(3,"Пока не уверен(а)"),
             new SendSring(4,"Скорее нет"),
             new SendSring(5,"Нет"),
             });

        Container.BindInterfacesAndSelfTo<Question_20>()
           .AsSingle()
           .WithArguments(20, Page_20, new List<SendSring>()
             {
             new SendSring(1,"До 18"),
             new SendSring(2,"18–24"),
             new SendSring(3,"25–34"),
             new SendSring(4,"35–44"),
             new SendSring(5,"45"),
             });

        Container.BindInterfacesAndSelfTo<Question_21>()
           .AsSingle()
           .WithArguments(21, Page_21, new List<SendSring>()
             {
             new SendSring(1,"Очень часто"),
             new SendSring(2,"Иногда"),
             new SendSring(3,"Редко"),
             new SendSring(4,"Практически никогда"),
             });

        Container.BindInterfacesAndSelfTo<Question_22>()
           .AsSingle()
           .WithArguments(22, Question_22_InputField_1);

        Container.BindInterfacesAndSelfTo<Question_23>()
           .AsSingle()
           .WithArguments(23, Page_23, Question_23_InputField_1, new List<SendSring>()
             {
             new SendSring(1,"Steam"),
             new SendSring(2,"TikTok"),
             new SendSring(3,"Instagram"),
             new SendSring(4,"YouTube / Shorts"),
             new SendSring(5,"Twitch / стример"),
             new SendSring(6,"Reddit"),
             new SendSring(7,"Медиа / статья"),
             new SendSring(8,"Друг / знакомый"),
             });
    }
}

[Serializable]
public class PageButton
{
    public int IdPage;
    public Button NextPage;
    public GameObject LastPage;
}


public class Main_ButtonSEND
{
    public Button _main_ButtonSEND;
    public List<PageButton> _pageButtons;

    public Main_ButtonSEND(Button Main_ButtonSEND, List<PageButton> pageButtons)
    {
        _main_ButtonSEND = Main_ButtonSEND;
        _pageButtons = pageButtons;
    }
}