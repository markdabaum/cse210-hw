public class Reflection : Activity
{
    private List<string> _promptList = [
        "Think of a time when you stodd up for someone else.",
        "Think of a time when you did something really difficult",
        "Think of a time when you helped someone in need",
        "Think of a time whe you did something truly selfless"
    ];

    private List<string> _questionList = [
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ];

    public Reflection(string actType) : base(actType)
    {
        _description = "This activity will help you relax by offering prompts and questions to relfect on";
    }

    public int Reflect()
    {
        DisplayStartMessage();
        SetTimer();

        int timer = GetTimer();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(timer);

        Random randomGenerator = new();
        int promptIndex = randomGenerator.Next(0,_promptList.Count);
        
        Console.Clear();
        Console.WriteLine($"{_promptList[promptIndex]}");
        Animation();
        Animation();

        while (DateTime.Now < endTime){
            int questionIndex = randomGenerator.Next(0,_questionList.Count);
            Console.WriteLine($"{_questionList[questionIndex]}");
            for(int i=0; i<3; i++)
                Animation();
            Console.WriteLine(" ");
        }
        
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