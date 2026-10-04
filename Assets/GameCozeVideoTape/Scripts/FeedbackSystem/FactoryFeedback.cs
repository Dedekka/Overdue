using System.Collections.Generic;
using Zenject;

public class FactoryFeedback
{
    private List<ControlFeedback> _controlFeedback;

    public FactoryFeedback(Question_1 question_1, Question_2 question_2 )
    {
        _controlFeedback = new List<ControlFeedback>()
        {
            question_1,
            question_2,
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
        string temp = _controlFeedback.Find((x)=>x.ID == id).Question_Text;

        return temp;
    }

}
