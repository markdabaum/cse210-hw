public class Simple : Goal
{

    public override void CreateGoal()
    {
        base.CreateGoal();
        _goalType = "Simple";
    }

// Each child class adds to what is saved as is necessary.
    public override string SaveGoal()
    {
        return base.SaveGoal() + $"|{_status}";
    }

// Each child class save additional information as necessary.
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