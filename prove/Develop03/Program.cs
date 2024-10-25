using System;
using System.Net;
using System.Reflection.Metadata;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        // Setting up variables and initializing classes
        Scripture scripture = new();
        Reference reference = new();
        string preset;
        string enter = "";
        string repeat = "";
        bool firstTime;

        Console.Clear();
        Console.WriteLine("Scripture Memorizer");
        do{
            /* This is the first part of my exceeding requirements. Giving the user 
            the opportunity to enter a verse of their choice.
            I only wish the terminal would let you copy and paste. */
            Console.Write("Use preset scripture Moses 1:39? (y/n): ");
            preset = Console.ReadLine();

            if (preset != "y" && preset != "n")
                Console.WriteLine("Invalid response");

        }while (preset != "y" && preset != "n");
        
        switch (preset)
        {
            /*Using switch allows a really easy way to re-initialize my classes 
            however is needed for the program*/
            case "y":
                reference = new Reference();
                scripture = new Scripture();
                break;

            case "n":
                Console.WriteLine("Enter the scripture reference (ie: Moses 1:39):");
                string userReference = Console.ReadLine();

                // Please let me copy (in the terminal) and my soul will be yours!
                Console.WriteLine("Enter the scripture contents:");
                string userScripture = Console.ReadLine();

                reference = new Reference(userReference);
                scripture = new Scripture(userScripture);
                break;
        }
        
        /*This do while loop use to be about twice the length 
        that it currently is. Using bool firstTime really cut 
        on the space I was using down*/
        do
        {
            firstTime = true;
            while (!scripture.AllBlank())
            {
                Console.Clear();
                Console.WriteLine("Scripture Memorizer");
                if (!firstTime)
                {
                    scripture.HideWords();
                }
                //These do exactly what you think
                reference.DisplayReference();
                scripture.DisplayScripture();

                Console.WriteLine("Press enter to continue or type 'quit' to end the program:");
                enter = Console.ReadLine();
                if (enter == "quit")
                    break;
                firstTime = false;
            }
            /*And this is the second part of my exceeding requirements, allowing the user to 
            reset the program and start again. This was they don't have to type the whole
            scripture in again if they did that in the first place.*/
            if (enter != "quit")
            {
                Console.Write("Would you like to repeat this exersize? (y/n) ");
                repeat = Console.ReadLine();

                string userScripture = scripture.GetScript();
                scripture = new Scripture(userScripture);
            }

            if (repeat != "y")
                enter = "quit";
            else
                enter = "";
        }while (enter != "quit");

        Console.WriteLine("Goodbye");
    }
}