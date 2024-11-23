public class Eternal : Goal
{

    public string _dateCheck;

    public override void CreateGoal()
    {
        base.CreateGoal();
        _goalType = "Eternal";
        _dateCheck = " ";
    }

    public override string SaveGoal()
    {
        return base.SaveGoal() + $"|{_status}|{_dateCheck}";
    }

    public override void LoadGoal(string[] attributes)
    {
        DateTime today = DateTime.Now;

        base.LoadGoal(attributes);
        _status = attributes[3] == "True";
        _dateCheck = attributes[4];
        _goalType = "Eternal";

        if (_dateCheck != today.ToShortDateString())
            _status = false;
    }

    public override int RecordGoal()
    {
        DateTime today = DateTime.Now;

        if (_dateCheck == today.ToShortDateString()){
            Console.WriteLine("You have already completed this goal today");
            return 0;
        }

        else{
            _dateCheck = today.ToShortDateString();
            _status = true;
            return GetPointValue();
        }
        
    }
}