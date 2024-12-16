using System.ComponentModel;

public class Player
{
    private Deck _playerDeck;
    protected Deck _playerHand;
    protected Pokie _primary;
    protected Deck _bench;
    private int _points = 0;

    public void SetPlayerDeck(Deck deck)
    {
        _playerDeck = deck;
        _playerDeck.ShuffleDeck();
    }

    public int GetPoints()
    {
        return _points;
    }
    
    public void DrawHand()
    {
        _playerHand = new(_playerDeck);
    }

    public void DrawCard()
    {
        Console.WriteLine("Looking for Pokies");
        Thread.Sleep(1000);
        if (_playerDeck.GetDeckCount() != 0)
        {
            _playerHand = _playerDeck.MoveToDeck(_playerHand, _playerDeck.GetDeckCount()-1);
            Console.WriteLine("You found a pokie!");
        }
        else
            Console.WriteLine("No more Pokies to find.");
        Thread.Sleep(1000);
    }

    public virtual void PlaceCards(int turnCounter){}

    public virtual void GiveCourage(int counter){}

    public virtual int Attack(int turnCount){return 0;}

    public virtual void GetDamage(int damage)
    {
        Console.WriteLine($"You delt {damage} damage");
        int primaryHealth;

        if (_primary != null)
        {
            primaryHealth = _primary.TakeDamage(damage);
            if (primaryHealth <= 0)
            {
                Console.WriteLine($"{_primary.GetName()} has fainted!");
                _primary = null;
                _points ++;
            }
        }
    }

    
}