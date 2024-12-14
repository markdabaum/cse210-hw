using System.Runtime.InteropServices;

public class UserPlayer: Player
{
    public override void PlaceCards(int turnCounter)
    {
        Console.WriteLine($"Turn {turnCounter}\n");

        bool continueTurn = true;
        int index;
        while (continueTurn){
            Console.WriteLine("You Primary Pokie:\n");
            if (_primary != null)
                _primary.DisplayStats();

            Console.WriteLine("Your bench:\n");
            if (_bench != null)
                _bench.DisplayDeck();

            Console.WriteLine("Your Hand:\n");
            if (_playerHand != null)
                _playerHand.DisplayDeck();

            if (_primary == null)
            {
                Console.Write($"Set a Pokie as your Primary (1-{_playerHand.GetDeckCount()}): ");
                index = int.Parse(Console.ReadLine()) - 1;
                _primary = _playerHand.GivePokie(index);
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
    
}