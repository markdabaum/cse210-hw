using System.Security.Cryptography.X509Certificates;

public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string name, string topic, string section, string problems) : base(name, topic)
    {
        _textbookSection = section;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        string homeworkList = $"{_textbookSection} {_problems}";
        return homeworkList;
    }
}