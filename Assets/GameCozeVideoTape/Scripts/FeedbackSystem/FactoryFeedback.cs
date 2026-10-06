using System.Collections.Generic;

public class FactoryFeedback
{
    private List<ControlFeedback> _controlFeedback;

    public FactoryFeedback
        (Question_1 question_1,
        Question_2 question_2,
        Question_3 question_3,
        Question_4 question_4,
        Question_5 question_5,
        Question_6 question_6,
        Question_7 question_7,
        Question_8 question_8,
        Question_9 question_9,
        Question_10 question_10,
        Question_11 question_11,
        Question_12 question_12,
        Question_13 question_13,
        Question_14 question_14,
        Question_15 question_15,
        Question_16 question_16,
        Question_17 question_17,
        Question_18 question_18,
        Question_19 question_19,
        Question_20 question_20,
        Question_21 question_21,
        Question_22 question_22,
        Question_23 question_23
        )
    {
        _controlFeedback = new List<ControlFeedback>()
        {
            question_1,
            question_2,
            question_3,
            question_4,
            question_5,
            question_6,
            question_7,
            question_8,
            question_9,
            question_10,
            question_11,
            question_12,
            question_13,
            question_14,
            question_15,
            question_16,
            question_17,
            question_18,
            question_19,
            question_20,
            question_21,
            question_22,
            question_23
        };

    }

    public void PrePost()
    {
        for (int i = 0; i < _controlFeedback.Count; i++)
        {
            _controlFeedback[i].PreSend();
        }
    }

    public string GetFeedback(int id)
    {
        ControlFeedback tempSendSring = _controlFeedback.Find((x) => x.ID == id);
        string temp_Text = tempSendSring == null ? "" : tempSendSring.Question_Text;
        return temp_Text;
    }

}
