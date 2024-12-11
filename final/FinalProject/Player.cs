using System.ComponentModel;

public class Player
{
    private Deck _playerDeck;
    private Deck _playerHand;
    private UserBattle _playerBattle;
    private CPUBattle _cpuBattle;

    public Player(UserBattle ubattle)
    {
        _playerBattle = ubattle;
    }

    public Player(UserBattle cBattle, CPUBattle ubattle)
    {
        _playerBattle = cBattle;
        _cpuBattle = ubattle;
    }

    public void SetPlayerDeck(Deck deck)
    {
        _playerDeck = deck;
        _playerDeck.ShuffleDeck();
    }

    
}