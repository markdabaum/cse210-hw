using System;
using System.Security;

class Program
{
    static void Main(string[] args)
    {
        
        UserPlayer player1 = new();
        UserPlayer player2 = new();
        CPUPlayer playerc = new();

        Random randomGenerator = new();

        int deckChoice = 0;
        int turnCount = 1;
        int choice1 = 0;
        int choice2 = 0;
       

        Console.WriteLine("Welcome to Poke-A-Man!\n");

        do{ //Player 1 Starting Menu
            Console.WriteLine("Player 1:");
            Console.WriteLine("\t1. Pick Deck");
            Console.WriteLine("\t2. View Decks");
            Console.Write("Enter your choice: ");
            choice1 = int.Parse(Console.ReadLine());

            Deck fireDeck = new("deck_fire.csv");
            Deck waterDeck = new("deck_water.csv");
            Deck earthDeck = new("deck_earth.csv");
            
            switch (choice1)
            {
                case 1:
                    Console.WriteLine("Pick your deck from the options below:");
                    Console.WriteLine("\t1. Fire");
                    Console.WriteLine("\t2. Water");
                    Console.WriteLine("\t3. Earth");
                    Console.Write("Enter your Deck Choice: ");
                    deckChoice = int.Parse(Console.ReadLine());


                    switch (deckChoice)
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

            Deck fireDeck2 = new("deck_fire.csv");
            Deck waterDeck2 = new("deck_water.csv");
            Deck earthDeck2 = new("deck_earth.csv");

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
                        player2.SetPlayerDeck(fireDeck2);
                        break;

                        case 2:
                        player2.SetPlayerDeck(waterDeck2);
                        break;

                        case 3:
                        player2.SetPlayerDeck(earthDeck2);
                        break;
                    }
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Fire Deck:\n");
                    fireDeck2.DisplayDeck();
                    Console.WriteLine("Water Deck:\n");
                    waterDeck2.DisplayDeck();
                    Console.WriteLine("Earth Deck:\n");
                    earthDeck2.DisplayDeck();
                    break;
                
                case 3:
                    deckchoice = randomGenerator.Next(1, 3);

                    switch (deckchoice)
                    {
                        case 1:
                        playerc.SetPlayerDeck(fireDeck2);
                        break;

                        case 2:
                        playerc.SetPlayerDeck(waterDeck2);
                        break;

                        case 3:
                        playerc.SetPlayerDeck(earthDeck2);
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

        int playerTurn = randomGenerator.Next(0, 2);

        player1.DrawHand();

        if (choice2 == 3)
        {
            playerc.DrawHand();
        }
        else if (choice2 == 1)
        {
            player2.DrawHand();
        }



        bool battle = true;

        while (battle)
        {
            if (playerTurn == 1)
            {
                if (turnCount > 2)
                    player1.DrawCard();
                Console.Clear();
                Console.WriteLine("Player 1: ");
                player1.PlaceCards(turnCount);
                playerTurn--;
            }
            else
            {
                if (turnCount > 2)
                    player2.DrawCard();
                Console.Clear();
                Console.WriteLine("Player 2");
                player2.PlaceCards(turnCount);
                playerTurn++;
            }
            turnCount++;
        }




    }
}