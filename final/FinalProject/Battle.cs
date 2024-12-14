public class Battle
{
    private bool _firstTurn = true;
    private int _turnCount = 1;
    private Pokie _primaryPokie;
    private List<Pokie> _benchPokies = [];

    public int GetTurn()
    {
        return _turnCount;
    }

    // public void DrawHand()
    // {
    //     Deck deck = Player.GetPlayerDeck()
    // }
}