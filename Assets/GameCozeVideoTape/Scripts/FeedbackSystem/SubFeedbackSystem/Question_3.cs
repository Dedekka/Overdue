using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Question_3 : ControlFeedback
{
    private DataQuestion_3 _dataQuestion;
    private const string Question_1_Toggle_1 = "Как подбирать и ставить кассеты";
    private const string Question_1_Toggle_2 = "Как переключаться между кассетами в руках";
    private const string Question_1_Toggle_3 = "Как определить нужную полку по жанру и поджанру";
    private const string Question_1_Toggle_4 = "Как использовать обложку, название и стикер как подсказки";
    private const string Question_1_Toggle_5 = "Как пользоваться видеомагнитофоном";
    private const string Question_1_Toggle_6 = "Как отвечать на телефон";
    private const string Question_1_Toggle_7 = "Где искать возвращённые клиентами кассеты";

    public Question_3(int id, DataQuestion_3 dataQuestion_3) : base(id)
    {
        _dataQuestion = dataQuestion_3;
    }

    protected override void Disposeble()
    {
        throw new System.NotImplementedException();
    }

    protected override void Initialization()
    {
        throw new System.NotImplementedException();
    }

    private void SetText()
    {
        Question_Text = string.Empty;

        Question_Text += CheckText(_dataQuestion.Question_Toggle_1, Question_1_Toggle_1);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion.Question_Toggle_2, Question_1_Toggle_2);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion.Question_Toggle_3, Question_1_Toggle_3);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion.Question_Toggle_4, Question_1_Toggle_4);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion.Question_Toggle_5, Question_1_Toggle_5);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion.Question_Toggle_6, Question_1_Toggle_6);
        Question_Text += " , ";
        Question_Text += CheckText(_dataQuestion.Question_Toggle_7, Question_1_Toggle_7);
        Question_Text += " , ";
        Question_Text += _dataQuestion.Question_InputField.text;
    }

    public override void PreSend() { SetText(); }

    private string CheckText(Toggle toggle, string text)
    {
        string question_Text;

        question_Text = toggle.isOn ? $",{text}" : "";

        return question_Text;
    }

}

public class DataQuestion_3
{
    public Toggle Question_Toggle_1;
    public Toggle Question_Toggle_2;
    public Toggle Question_Toggle_3;
    public Toggle Question_Toggle_4;
    public Toggle Question_Toggle_5;
    public Toggle Question_Toggle_6;
    public Toggle Question_Toggle_7;
    public TMP_InputField Question_InputField;


    public DataQuestion_3
       (
   Toggle Question_1_Toggle_1,
   Toggle Question_1_Toggle_2,
   Toggle Question_1_Toggle_3,
   Toggle Question_1_Toggle_4,
   Toggle Question_1_Toggle_5,
   Toggle Question_1_Toggle_6,
   Toggle Question_1_Toggle_7,
  TMP_InputField Question_InputField
       )
    {
        this.Question_Toggle_1 = Question_1_Toggle_1;
        this.Question_Toggle_2 = Question_1_Toggle_2;
        this.Question_Toggle_3 = Question_1_Toggle_3;
        this.Question_Toggle_4 = Question_1_Toggle_4;
        this.Question_Toggle_5 = Question_1_Toggle_5;
        this.Question_Toggle_6 = Question_1_Toggle_6;
        this.Question_Toggle_7 = Question_1_Toggle_7;
        this.Question_InputField = Question_InputField;
    }

}