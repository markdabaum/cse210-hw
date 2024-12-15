using System.ComponentModel;

public class Player
{
    private Deck _playerDeck;
    protected Deck _playerHand;
    protected Pokie _primary;
    protected Deck _bench;
    private int _points;

    public void SetPlayerDeck(Deck deck)
    {
        _playerDeck = deck;
        _playerDeck.ShuffleDeck();
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
            _playerHand = _playerDeck.MoveToDeck(_playerHand, _playerDeck.GetDeckCount()-1);
        else
            Console.WriteLine("No more Pokies to find.");
    }

    public virtual void PlaceCards(int turnCounter){}

    public virtual void GiveCourage(){}

    public virtual void Attack(){}

    
}