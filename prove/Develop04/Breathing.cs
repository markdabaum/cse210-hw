using System.Globalization;

public class Breathing : Activity
{
    public Breathing(string actType) : base(actType)
    {
        _description = "This activity will help you relax by walking you through breathing in and out slowly.";
    }

    public int Breath()
    {
        DisplayStartMessage();
        SetTimer();

        int timer = GetTimer();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(timer);

        Console.Clear();
        Console.WriteLine("Take a moment to clear your mind");
        Animation();

        while ( DateTime.Now < endTime) {
            int cursorBreath = Console.CursorTop;
            Console.WriteLine("Breath in ");
            
            int length = 40;
            for(int i=0; i<length & DateTime.Now < endTime; i++)
            {
                Console.Write("->\b");
                Thread.Sleep(100);
            }
            int cursorAni = Console.CursorTop;
            Console.Write(" \n");

            Console.SetCursorPosition(0, cursorBreath);
            Console.WriteLine("Breath out");

            Console.SetCursorPosition(length+1, cursorAni);
            for(int j=0; j<length & DateTime.Now < endTime; j++)
            {
                Console.Write("\b\b\b< ");
                Thread.Sleep(150);
            }
            Console.Write("\b\b  \b");
            Console.SetCursorPosition(0, cursorBreath);
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