public class Goal
{
    List<Goal> _goalList = [];

    protected string _goalType = "";
    protected bool _status = false;
    private string _goalTitle = "";
    private string _goalDescription = "";
    private int _pointValue = 0;

// Some getters and setters. I could've use more, but I'd rather just have some variables protected instead
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

// Everthing else is a virtual method to be overriden by the child classes.
    public virtual string DisplayGoal()
    {
        string checkmark = " ";

        if (_status)
            checkmark = "X";
        return $"[{checkmark}] {_goalTitle} ({_goalDescription})";
    }

// CreateGoal is as close as we get to contructors in this program.
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
    
    // This method ended up being different enough for each class that I didn't bother specifying any real functionality here
    public virtual int RecordGoal()
    {
        return _pointValue;
    }
}