public class Listing : Activity
{
    private List<string> _promptList = [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of you personal heroes?"
    ];

    public Listing(string actType) : base(actType)
    {
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area";
    }

    public int List()
    {
        DisplayStartMessage();
        SetTimer();

        int timer = GetTimer();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(timer);
        int listCount = 0;

        Random randomGenerator = new();
        int promptIndex = randomGenerator.Next(0,_promptList.Count);
        
        Console.Clear();
        Console.WriteLine($"{_promptList[promptIndex]}");
        Animation();

        Console.WriteLine("You may begin your list:");
        while(DateTime.Now < endTime)
        {
            Console.ReadLine();
            listCount++;
        }     
        Console.WriteLine($"You listed {listCount} items!");   

        DisplayEndMessage();

        Console.Write("Hit enter to return to continue, or type 'quit' to exit the program: ");
        string s = Console.ReadLine();
        int q;
        if (s == "quit"){
            q = 5;}
        else{
            q = 0;}
        
        return q;
    }
}