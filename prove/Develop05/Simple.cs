public class Simple : Goal
{

    // public Simple(string goalType, string goalTitle, string goalDescription, int pointValue, string status) : base(goalType, goalTitle, goalDescription, pointValue)
    // {
    //     _status = status;
    // }


    public override void CreateGoal()
    {
        base.CreateGoal();
        _goalType = "Simple";
    }

    public override string DisplayGoal()
    {
        return base.DisplayGoal();
    }

    public override string SaveGoal()
    {
        return base.SaveGoal() + $"|{_status}";
    }

    public override void LoadGoal(string[] attributes)
    {
        base.LoadGoal(attributes);
        _status = attributes[3] == "True";
        _goalType = "Simple";
    }

    public override int RecordGoal()
    {
        if (_status){
            Console.WriteLine("You have already completed this goal");
            return 0;
        }
        else{
            _status = true;
            return GetPointValue();
        }
    }
}