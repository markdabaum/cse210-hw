using System.Runtime.InteropServices;

public class UserPlayer: Player
{
    public void DisplayPlayerInfo(int counter, bool midturn)
    {
        Console.Clear();
        Console.WriteLine($"Turn {counter}\n");

        int displayCount = 0;

            if (_bench != null)
                displayCount = _bench.GetDeckCount();

        Console.WriteLine("Your Primary Pokie:\n");
        if (_primary != null)
            _primary.DisplayStats();

        Console.WriteLine("Your bench:\n");
        if (_bench != null)
        {
            if (_bench.GetDeckCount() > 0)
                _bench.DisplayDeck(midturn, 0);
        }
        Console.WriteLine("Your Hand:\n");
        if (_playerHand != null || _playerHand.GetDeckCount() > 0)
        {
            if (_playerHand.GetDeckCount() > 0)
                _playerHand.DisplayDeck(midturn, displayCount);   
        }
    }

    public override void PlaceCards(int turnCounter)
    {

        bool continueTurn = true;
        bool midturn = false;
        int index;

        while (continueTurn){
            DisplayPlayerInfo(turnCounter, midturn);

            int displayAdjustment = 0;
                if (_bench != null)
                    displayAdjustment += _bench.GetDeckCount();

            if (_primary == null)
            {
                if (turnCounter <= 2 || _bench.GetDeckCount() == 0)
                {
                    Console.Write($"Set a Pokie as your Primary (1-{_playerHand.GetDeckCount()}): ");
                    index = int.Parse(Console.ReadLine()) - 1;
                    _primary = _playerHand.GivePokie(index);
                    DisplayPlayerInfo(turnCounter, midturn = true);
                    continueTurn = false;
                }
                else
                {
                    Console.WriteLine($"Set a Pokie from your bench as your Primary: (1-{_bench.GetDeckCount()})");
                    index = int.Parse(Console.ReadLine()) - 1;
                    _primary = _bench.GivePokie(index);
                    DisplayPlayerInfo(turnCounter, midturn = true);
                    continueTurn = false;
                }
            }
            
            else{
                if(_bench == null || _bench.GetDeckCount() < 2)
                {
                    Console.Write($"You may move one Pokie from your hand to the bench ({1+displayAdjustment} - {displayAdjustment + _playerHand.GetDeckCount()}, or enter \"0\" to skip): ");
                    index = int.Parse(Console.ReadLine()) - displayAdjustment;

                    if (index != 0)
                    {
                        index--;
                        
                        _bench = _playerHand.MoveToDeck(_bench, index);
                        DisplayPlayerInfo(turnCounter, midturn = true);
                    }
                    else
                        Console.WriteLine("That Pokie is already on your bench!");
                    continueTurn = false;
                }
                else
                {
                    Console.WriteLine("Your bench is full!");
                    continueTurn = false;
                }
            }
        }
    }

    public override void GiveCourage(int counter)
    {
        Console.WriteLine("You may give Courage to your Primary Pokie or one of your benched Pokies");
        if (_bench == null || _bench.GetDeckCount() == 0)
            Console.WriteLine($"(\"0\" for Primary)");
        else
            Console.Write($"(1-{_bench.GetDeckCount()}, \"0\" for Primary): ");

        int index = int.Parse(Console.ReadLine());
        
        if (index == 0)
        {
            _primary.ReceiveCourage();
        }

        else if (index <= _bench.GetDeckCount())
        {
            _bench.DisperseCourage(index--);
        }

        else
            Console.WriteLine("Invalid Input. No Courage given.");
        
        DisplayPlayerInfo(counter, true);
        Thread.Sleep(1000);
    }

    public override int Attack(int turnCount)
    {
        if (turnCount > 2)
        {

            if (_primary != null)
            {
                Console.WriteLine("Your primary Pokie may perform an action!");
                Console.WriteLine("\t1. Basic Attack");
                Console.WriteLine("\t2. Secondary Action");
                Console.Write("Enter your choice here (\"0\" to skip): ");
                int action = int.Parse(Console.ReadLine());
                int damage = 0;
                if (action == 1)
                    damage = _primary.GetAttack();
                else if (action == 2)
                    damage = _primary.UseSecondary();

                return damage;
            }
            else
                return 0;
        }  
        else
            return 0;
    }
}