using System.Runtime.InteropServices;

public class UserPlayer: Player
{
    public void DisplayPlayerInfo(int counter, bool midturn)
    {
        Console.Clear();
        Console.WriteLine($"Turn {counter}\n");

        Console.WriteLine("You Primary Pokie:\n");
        if (_primary != null)
            _primary.DisplayStats();

        Console.WriteLine("Your bench:\n");
        if (_bench != null)
            _bench.DisplayDeck(midturn);

        Console.WriteLine("Your Hand:\n");
        if (_playerHand != null)
            _playerHand.DisplayDeck(midturn);   
    }

    public override void PlaceCards(int turnCounter)
    {

        bool continueTurn = true;
        bool midturn = false;
        int index;

        while (continueTurn){
            DisplayPlayerInfo(turnCounter, midturn);

            if (_primary == null)
            {
                Console.Write($"Set a Pokie as your Primary (1-{_playerHand.GetDeckCount()}): ");
                index = int.Parse(Console.ReadLine()) - 1;
                _primary = _playerHand.GivePokie(index);
                DisplayPlayerInfo(turnCounter, midturn = true);
                continueTurn = false;
            }
            
            else{
                if(_bench == null || _bench.GetDeckCount() <=2)
                {
                    Console.Write($"You may move one Pokie from your hand to the bench (1-{_playerHand.GetDeckCount()}, or enter \"0\" to skip): ");
                    index = int.Parse(Console.ReadLine());
                    
                    if (index != 0)
                    {
                        index--;
                        _bench = _playerHand.MoveToDeck(_bench, index);
                        DisplayPlayerInfo(turnCounter, midturn = true);
                    }
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

    public override void GiveCourage()
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
    }

    public override void Attack()
    {
        
    }

}