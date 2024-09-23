using System;

class Program
{
    static void Main(string[] args)
    {
        string again = "yes";
        
        while (again == "yes")
        {
            Random randomGenerator = new Random();
            int num = randomGenerator.Next(0, 101);
            // int num = 40;
            int guess;
            int guessCount = 0;

            Console.WriteLine ("\nGuess the number!");
            do
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();
                guess = int.Parse(input);

                if (num > guess)
                {
                    Console.WriteLine("Too low!");
                }
                else if (num < guess)
                {
                    Console.WriteLine("Too high");
                }

                guessCount++;

            } while (guess != num);
            
            string plural;

            if (guessCount == 1)
            {
                plural = "y";
            }
            else
            {
                plural = "ies";
            }
            Console.WriteLine($"You got it in {guessCount} tr{plural}!\n");

            Console.Write("Play again (Yes/No)? ");
            again = Console.ReadLine();
        }
        Console.WriteLine("Goodbye");
    }
}