public class Activity
{
    private string _startMessage;
    protected string _description = "";
    private string _endMessage;
    private int _timeRequest;

    public Activity(string activityType)
    {
        _startMessage = $"Welcome to the {activityType} Activity";
        _endMessage = $"You have completed the {activityType} Activity\n";
    }

    public void SetTimer()
    {
        Console.Write("How long, in seconds, would you like to spend on this activity? ");
        string timeRequest = Console.ReadLine();
        _timeRequest = int.Parse(timeRequest);
    }

    public int GetTimer()
    {
        return _timeRequest;
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"{_startMessage}");
        Console.WriteLine($"{_description}");
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine($"{_endMessage}");
    }

    public void Animation()
    {
        List<string> animation = [
            "|",
            "/",
            "--",
            "\\",
            "|"
        ];

        int success = 0;
        do{
            foreach (string i in animation)
            {
                Console.Write($"{i}\b");
                Thread.Sleep(25);
            }
            success += 1;
        } while (success != 10);

        for(int j=0; j<10; j++)
        {
            Console.Write(" \b\b");
            Thread.Sleep(75);
        }
    }
}