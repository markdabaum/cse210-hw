public class Goal
{
    List<Goal> _goalList = [];

    protected string _goalType = "";
    protected bool _status = false;
    private string _goalTitle = "";
    private string _goalDescription = "";
    private int _pointValue = 0;

    // public Goal(string goalType, string goalTitle, string goalDescription, int pointValue)
    // {
    //     _goalType = goalType;
    //     _goalTitle = goalTitle;
    //     _goalDescription = goalDescription;
    //     _pointValue = pointValue;
    // }

    public void AddToList(Goal goal)
    {
        _goalList.Add(goal);
    }

    public List<Goal> GetList()
    {
        return _goalList;
    }

    public int GetPointValue()
    {
        return _pointValue;
    }

    public virtual string DisplayGoal()
    {
        string checkmark = " ";

        if (_status)
            checkmark = "X";
        return $"[{checkmark}] {_goalTitle} ({_goalDescription})";
    }

    public virtual void CreateGoal()
    {
        _goalType = "Goal";

        Console.Write("What is the name of your goal? ");
        _goalTitle = Console.ReadLine();

        Console.Write("What is a short description of the goal? ");
        _goalDescription = Console.ReadLine();

        Console.Write("What is the point value of this goal? ");
        _pointValue = int.Parse(Console.ReadLine());
    }

    public virtual int RecordGoal()
    {
        return _pointValue;
    }

    public virtual string SaveGoal()
    {
       return $"{_goalType}:{_goalTitle}|{_goalDescription}|{_pointValue}";
    }

    public virtual void LoadGoal(string[] attributes)
    {
        _goalTitle = attributes[0];
        _goalDescription = attributes[1];
        _pointValue = int.Parse(attributes[2]);
    }
    
}