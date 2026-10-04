using UnityEngine.UI;

public class Question_2 : ControlFeedback
{
    DataQuestion_2 _dataQuestion_1;

    private const string Question_2_Toggle_1 = "Почти всегда понимал(а) сразу";
    private const string Question_2_Toggle_2 = "Обычно понимал(а) после изучения обложки";
    private const string Question_2_Toggle_3 = "Иногда приходилось долго разбираться";
    private const string Question_2_Toggle_4 = "Часто приходилось угадывать";
    private const string Question_2_Toggle_5 = "Почти никогда не понимал(а), куда её ставить";

    public Question_2(int id, DataQuestion_2 dataQuestion_1) : base(id)
    {
        _dataQuestion_1 = dataQuestion_1;
    }

    protected override void Initialization()
    {
        //_dataQuestion_1.Question_2_Toggle_1.onValueChanged.AddListener((x) => AllDisable(1, x));
        //_dataQuestion_1.Question_2_Toggle_2.onValueChanged.AddListener((x) => AllDisable(2, x));
        //_dataQuestion_1.Question_2_Toggle_3.onValueChanged.AddListener((x) => AllDisable(3, x));
        //_dataQuestion_1.Question_2_Toggle_4.onValueChanged.AddListener((x) => AllDisable(4, x));
        //_dataQuestion_1.Question_2_Toggle_5.onValueChanged.AddListener((x) => AllDisable(5, x));
    }

    protected override void Disposeble()
    {
        //_dataQuestion_1.Question_2_Toggle_1.onValueChanged.RemoveAllListeners();
        //_dataQuestion_1.Question_2_Toggle_2.onValueChanged.RemoveAllListeners();
        //_dataQuestion_1.Question_2_Toggle_3.onValueChanged.RemoveAllListeners();
        //_dataQuestion_1.Question_2_Toggle_4.onValueChanged.RemoveAllListeners();
        //_dataQuestion_1.Question_2_Toggle_5.onValueChanged.RemoveAllListeners();
    }

    private void SetText()
    {
        Question_Text = string.Empty;

        Question_Text += CheckText(_dataQuestion_1.Question_2_Toggle_1, Question_2_Toggle_1);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion_1.Question_2_Toggle_2, Question_2_Toggle_2);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion_1.Question_2_Toggle_3, Question_2_Toggle_3);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion_1.Question_2_Toggle_4, Question_2_Toggle_4);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion_1.Question_2_Toggle_5, Question_2_Toggle_5);
    }

    public override void PreSend() { SetText(); }

    private string CheckText(Toggle toggle, string text)
    {
        string question_Text;

        question_Text = toggle.isOn ? $"{text}" : "";

        return question_Text;
    }

    //private void AllDisable(int id, bool isOn)
    //{
    //    if (!isOn) { return; }

    //    _dataQuestion_1.Question_2_Toggle_1.isOn = false;
    //    _dataQuestion_1.Question_2_Toggle_2.isOn = false;
    //    _dataQuestion_1.Question_2_Toggle_3.isOn = false;
    //    _dataQuestion_1.Question_2_Toggle_4.isOn = false;
    //    _dataQuestion_1.Question_2_Toggle_5.isOn = false;
    //    switch (id)
    //    {
    //        case 1:
    //            _dataQuestion_1.Question_2_Toggle_1.isOn = true;
    //            Question_Text = Question_2_Toggle_1;
    //            break;
    //        case 2:
    //            _dataQuestion_1.Question_2_Toggle_2.isOn = true;
    //            Question_Text = Question_2_Toggle_2;
    //            break;
    //        case 3:
    //            _dataQuestion_1.Question_2_Toggle_3.isOn = true;
    //            Question_Text = Question_2_Toggle_3;
    //            break;
    //        case 4:
    //            _dataQuestion_1.Question_2_Toggle_4.isOn = true;
    //            Question_Text = Question_2_Toggle_4;
    //            break;
    //        case 5:
    //            _dataQuestion_1.Question_2_Toggle_5.isOn = true;
    //            Question_Text = Question_2_Toggle_5;
    //            break;
  
}