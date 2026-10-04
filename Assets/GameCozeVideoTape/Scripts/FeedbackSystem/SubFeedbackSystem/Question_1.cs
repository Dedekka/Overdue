using UnityEngine.UI;

public class Question_1 : ControlFeedback
{
    DataQuestion_1 _dataQuestion_1;

    private const string Question_1_Toggle_1 = "Как подбирать и ставить кассеты";
    private const string Question_1_Toggle_2 = "Как переключаться между кассетами в руках";
    private const string Question_1_Toggle_3 = "Как определить нужную полку по жанру и поджанру";
    private const string Question_1_Toggle_4 = "Как использовать обложку, название и стикер как подсказки";
    private const string Question_1_Toggle_5 = "Как пользоваться видеомагнитофоном";
    private const string Question_1_Toggle_6 = "Как отвечать на телефон";
    private const string Question_1_Toggle_7 = "Где искать возвращённые клиентами кассеты";
    private const string Question_1_Toggle_8 = "Как размещать подарки";
    private const string Question_1_Toggle_9 = "Как менять музыку";
    private const string Question_1_Toggle_10 = "Обучение в целом было непонятным";

    public Question_1(int id, DataQuestion_1 dataQuestion_1) : base(id)
    {
        _dataQuestion_1 = dataQuestion_1;
    }

    protected override void Initialization()
    {
    }

    protected override void Disposeble()
    {
        //    _dataQuestion_1.Question_1_Toggle_1.onValueChanged.RemoveAllListeners();
        //    _dataQuestion_1.Question_1_Toggle_2.onValueChanged.RemoveAllListeners();
        //    _dataQuestion_1.Question_1_Toggle_3.onValueChanged.RemoveAllListeners();
        //    _dataQuestion_1.Question_1_Toggle_4.onValueChanged.RemoveAllListeners();
        //    _dataQuestion_1.Question_1_Toggle_5.onValueChanged.RemoveAllListeners();
        //    _dataQuestion_1.Question_1_Toggle_6.onValueChanged.RemoveAllListeners();
        //    _dataQuestion_1.Question_1_Toggle_7.onValueChanged.RemoveAllListeners();
        //    _dataQuestion_1.Question_1_Toggle_8.onValueChanged.RemoveAllListeners();
        //    _dataQuestion_1.Question_1_Toggle_9.onValueChanged.RemoveAllListeners();
        //    _dataQuestion_1.Question_1_Toggle_10.onValueChanged.RemoveAllListeners();
    }

    private void SetText()
    {
        Question_Text = string.Empty;

        Question_Text += CheckText(_dataQuestion_1.Question_1_Toggle_1, Question_1_Toggle_1);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion_1.Question_1_Toggle_2, Question_1_Toggle_2);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion_1.Question_1_Toggle_3, Question_1_Toggle_3);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion_1.Question_1_Toggle_4, Question_1_Toggle_4);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion_1.Question_1_Toggle_5, Question_1_Toggle_5);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion_1.Question_1_Toggle_6, Question_1_Toggle_6);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion_1.Question_1_Toggle_7, Question_1_Toggle_7);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion_1.Question_1_Toggle_8, Question_1_Toggle_8);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion_1.Question_1_Toggle_9, Question_1_Toggle_9);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion_1.Question_1_Toggle_10, Question_1_Toggle_10);
    }

    public override void PreSend() { SetText(); }

    private string CheckText(Toggle toggle, string text)
    {
        string question_Text;

        question_Text = toggle.isOn ? $",{text}" : "";

        return question_Text;
    }


}

public class DataQuestion_1
{
    public Toggle Question_1_Toggle_1;
    public Toggle Question_1_Toggle_2;
    public Toggle Question_1_Toggle_3;
    public Toggle Question_1_Toggle_4;
    public Toggle Question_1_Toggle_5;
    public Toggle Question_1_Toggle_6;
    public Toggle Question_1_Toggle_7;
    public Toggle Question_1_Toggle_8;
    public Toggle Question_1_Toggle_9;
    public Toggle Question_1_Toggle_10;

    public DataQuestion_1
        (
    Toggle Question_1_Toggle_1,
    Toggle Question_1_Toggle_2,
    Toggle Question_1_Toggle_3,
    Toggle Question_1_Toggle_4,
    Toggle Question_1_Toggle_5,
    Toggle Question_1_Toggle_6,
    Toggle Question_1_Toggle_7,
    Toggle Question_1_Toggle_8,
    Toggle Question_1_Toggle_9,
    Toggle Question_1_Toggle_10
        )
    {
        this.Question_1_Toggle_1 = Question_1_Toggle_1;
        this.Question_1_Toggle_2 = Question_1_Toggle_2;
        this.Question_1_Toggle_3 = Question_1_Toggle_3;
        this.Question_1_Toggle_4 = Question_1_Toggle_4;
        this.Question_1_Toggle_5 = Question_1_Toggle_5;
        this.Question_1_Toggle_6 = Question_1_Toggle_6;
        this.Question_1_Toggle_7 = Question_1_Toggle_7;
        this.Question_1_Toggle_8 = Question_1_Toggle_8;
        this.Question_1_Toggle_9 = Question_1_Toggle_9;
        this.Question_1_Toggle_10 = Question_1_Toggle_10;

    }
}