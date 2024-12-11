using System;
using System.Security;

class Program
{
    static void Main(string[] args)
    {
        Deck fireDeck = new("deck_fire.csv");
        Deck waterDeck = new("deck_water.csv");
        Deck earthDeck = new("deck_earth.csv");

        

        UserBattle p1Battle = new();
        UserBattle p2Battle = new();
        CPUBattle comBattle = new();
        
        Player player1 = new(p1Battle);
        Player player2 = new(p2Battle, comBattle);

        int choice1 = 0;
        int choice2 = 0;
        Random randomGenerator = new();

        Console.WriteLine("Welcome to Poke-A-Man!\n");

        do{ //Player 1 Starting Menu
            Console.WriteLine("Player 1:");
            Console.WriteLine("\t1. Pick Deck");
            Console.WriteLine("\t2. View Decks");
            Console.Write("Enter your choice: ");
            choice1 = int.Parse(Console.ReadLine());

            switch (choice1)
            {
                case 1:
                    Console.WriteLine("Pick your deck from the options below:");
                    Console.WriteLine("\t1. Fire");
                    Console.WriteLine("\t2. Water");
                    Console.WriteLine("\t3. Earth");
                    Console.Write("Enter your Deck Choice: ");
                    int deckchoice = int.Parse(Console.ReadLine());

                    switch (deckchoice)
                    {
                        case 1:
                        player1.SetPlayerDeck(fireDeck);
                        break;

                        case 2:
                        player1.SetPlayerDeck(waterDeck);
                        break;

                        case 3:
                        player1.SetPlayerDeck(earthDeck);
                        break;
                    }
                    break;

                case 2:
                    Console.Clear();
                    fireDeck.DisplayDeck();
                    waterDeck.DisplayDeck();
                    earthDeck.DisplayDeck();
                    break;
            }
        }while (choice1 != 1);
        Console.WriteLine();

        do{ //Player 2 Starting Menu
            Console.WriteLine("Player 2:");
            Console.WriteLine("\t1. Pick Deck");
            Console.WriteLine("\t2. View Decks");
            Console.WriteLine("\t3. Computer Player");
            Console.Write("Enter your choice: ");
            choice2 = int.Parse(Console.ReadLine());

            switch (choice2)
            {
                case 1:
                    Console.WriteLine("Pick your deck from the options below:");
                    Console.WriteLine("\t1. Fire");
                    Console.WriteLine("\t2. Water");
                    Console.WriteLine("\t3. Earth");
                    Console.Write("Enter your Deck Choice: ");
                    int deckchoice = int.Parse(Console.ReadLine());

                    switch (deckchoice)
                    {
                        case 1:
                        player2.SetPlayerDeck(fireDeck);
                        break;

                        case 2:
                        player2.SetPlayerDeck(waterDeck);
                        break;

                        case 3:
                        player2.SetPlayerDeck(earthDeck);
                        break;
                    }
                    break;

                case 2:
                    Console.Clear();
                    fireDeck.DisplayDeck();
                    waterDeck.DisplayDeck();
                    earthDeck.DisplayDeck();
                    break;
                
                case 3:
                    deckchoice = randomGenerator.Next(1, 3);

                    switch (deckchoice)
                    {
                        case 1:
                        player2.SetPlayerDeck(fireDeck);
                        break;

                        case 2:
                        player2.SetPlayerDeck(waterDeck);
                        break;

                        case 3:
                        player2.SetPlayerDeck(earthDeck);
                        break;
                    }
                    break;
            }
            if (choice2 == 3)
                break;
        }while (choice2 != 1);

        Console.Clear();
        Console.WriteLine("Ready..\n");
        Thread.Sleep(1000);
        Console.WriteLine("Set..\n");
        Thread.Sleep(2000);
        Console.WriteLine("Battle!");

        int playerTurn = randomGenerator.Next(0, 1);

        bool battle = true;


        // while (battle)
        // {
        //     if (playerTurn == 0)
        //     {
        //         p1Battle.
        //     }

        //     else if (playerTurn == 1)
        //     {
        //         if (choice2 == 3)
        //         {
        //             comBattle.
        //         }

        //         else 
        //         {
        //             p2Battle.
        //         }
        //     }
        // }




    }
}