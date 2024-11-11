using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        int userChoice;

        do{
            Console.Clear();

            
            List<string> menu = [
                "Start Breathing Activity",
                "Start Reflecting Activity",
                "Start Listing Activity",
                "Start All Activities",
                "Quit"
            ];

            Console.WriteLine("Welcome to the Mindfulness App\n");

            Console.WriteLine("Menu Options");
            for(int i=0; i < menu.Count; i++)
            {
                Console.WriteLine($"  {i+1}. {menu[i]}");
            }
            Console.Write($"Select a choice from the menu (1-{menu.Count}): ");
            string m = Console.ReadLine();
            userChoice = int.Parse(m);
            
            switch (userChoice){
                case 1:
                    Console.Clear();
                    Breathing breathing = new("Breathing");

                    userChoice = breathing.Breath();

                    break;

                case 2:
                    Console.Clear();
                    Reflection reflection = new("Reflection");

                    userChoice = reflection.Reflect();

                    break;

                case 3:
                    Console.Clear();
                    Listing listing = new("Listing");

                    userChoice = listing.List();

                    break;
                
                case 4:
                    Console.Clear();
                    Breathing breath = new("Breathing");
                    userChoice = breath.Breath();
                    if (userChoice == 5)
                        break;

                    Console.Clear();
                    Reflection reflect = new("Reflection");
                    userChoice = reflect.Reflect();
                    if (userChoice == 5)
                        break;

                    Console.Clear();
                    Listing list = new("Listing");
                    userChoice = list.List();

                    break;

                case 5:
                    break;

                default:
                    Console.WriteLine("Please select a valid option");
                    break;
            }
        }while (userChoice != 5);

        Console.WriteLine("GoodBye!");
    }
}