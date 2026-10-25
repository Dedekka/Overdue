public class ControlGoalTextIcon
{
    private CheckerTextIconTags _checkerTextIconTags;

    public ControlGoalTextIcon(CheckerTextIconTags checkerTextIconTags)
    {
        _checkerTextIconTags = checkerTextIconTags;
    }

    public string CheckTagIcon(string text)
    {
        return _checkerTextIconTags.CheckTag(text);
    }
}