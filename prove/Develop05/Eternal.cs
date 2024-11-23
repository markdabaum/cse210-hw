public class Eternal : Goal
{
/*This is the class where I exceeded requirements. I added a feature where you can only check off 
an eternal goal once a day. This was users can just have infinite points. This was implemented with
the string _dateCheck.
*/
    public string _dateCheck;

    public override void CreateGoal()
    {
        base.CreateGoal();
        _goalType = "Eternal";
        _dateCheck = " ";
    }

// Make sure to save the date!
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
// Some extra logic to ensure our checkmarks are correct when listing the goals.
        if (_dateCheck != today.ToShortDateString())
            _status = false;
    }

// When recording the goal, it doesn't even bother checking the status, just the date.
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