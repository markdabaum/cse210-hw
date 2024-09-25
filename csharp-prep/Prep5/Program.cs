using System;

class Program
{

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program");
    }

    static string PromptUserName()
    {
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Enter you favorite number: ");
        string input = Console.ReadLine();
        int userNumber = int.Parse(input);
        return userNumber;
    }

    static int SquareNumber(int num)
    {
        int numSquared = num * num;
        return numSquared;
    }

    static void DisplayResult(string name, int num, int num2)
    {
        Console.WriteLine($"{name}, the square of {num} is {num2}");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        int num = PromptUserNumber();
        int num2 = SquareNumber(num);
        
        DisplayResult(name, num, num2);
    }
}