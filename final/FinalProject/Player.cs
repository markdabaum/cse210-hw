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
        _playerHand = _playerDeck.MoveToDeck(_playerHand, _playerDeck.GetDeckCount()-1);
    }

    public virtual void PlaceCards(int turnCounter)
    {
    }

    
}