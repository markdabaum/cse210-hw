public class Checklist : Goal
{
//This class has the most extra stuff because it has to check for bonus material
    private int _bonus;
    private int _bonusCount;
    private int _bonusValue;

    public override void CreateGoal()
    {
        base.CreateGoal();
        _goalType = "Checklist";
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        _bonus = int.Parse(Console.ReadLine());
        _bonusCount = 0;
        Console.Write("What is the bonus for accomplishing it that many times? ");
        _bonusValue = int.Parse(Console.ReadLine());
    }

    public override string DisplayGoal()
    {
        return base.DisplayGoal() + $" -- Currently completed: {_bonusCount}/{_bonus}";
    }

    public override string SaveGoal()
    {
        return base.SaveGoal() + $"|{_bonusValue}|{_bonus}|{_bonusCount}";
    }

    public override void LoadGoal(string[] attributes)
    {
        base.LoadGoal(attributes);
        _bonusValue = int.Parse(attributes[3]);
        _bonus = int.Parse(attributes[4]);
        _bonusCount = int.Parse(attributes[5]);
        _goalType = "Checklist";
    }

    public override int RecordGoal()
    {
        int points = 0;
        if (_status){
            Console.WriteLine("You have already completed this goal");
            return 0;
        }
        else{
            _bonusCount++;
            points += GetPointValue();
            if (_bonusCount == _bonus)
            {
                points += _bonusValue;
                _status = true;
            }

        }
        return points;
    }
}