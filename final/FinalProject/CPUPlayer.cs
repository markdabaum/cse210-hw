public class CPUPlayer: Player
{
    Random _randomGenerator = new();
    public override void PlaceCards(int turnCounter)
    {
        bool continueTurn = true;
        int index;

        while (continueTurn){

            if (_primary == null) //Setting Primary Pokie
            {
                if (turnCounter <= 2 || _bench.GetDeckCount() == 0)
                {
                    index = _randomGenerator.Next(0, _playerHand.GetDeckCount());
                    _primary = _playerHand.GivePokie(index);
                    continueTurn = false;
                }
                else
                {
                    index = _randomGenerator.Next(0, _bench.GetDeckCount());
                    _primary = _bench.GivePokie(index);
                    continueTurn = false;
                }
            }
            
            else{
                if(_bench == null || _bench.GetDeckCount() < 2) //Moving Pokies to the bench
                {
                    index = _randomGenerator.Next(0, _playerHand.GetDeckCount());

                    if (index != 0)
                    {
                        index--;
                        
                        _bench = _playerHand.MoveToDeck(_bench, index);
                    }
                    continueTurn = false;
                }
                    continueTurn = false;
            }
        }
    }

    public override void GiveCourage(int counter)
    {
        int index = 0;
        if (_primary.GetCourage() >= _primary.GetMaxCourage() && _bench != null)
            index = _randomGenerator.Next(1, _bench.GetDeckCount());

        if (index == 0)
        {
            _primary.ReceiveCourage();
        }

        else if (index <= _bench.GetDeckCount())
        {
            _bench.DisperseCourage(index--);
        }
    }

    public override int Attack(int turnCount)
    {
        int damage = 0;

        if (turnCount > 2 && _primary != null)
        {
            int action = 0;

            if (_primary.GetType() == "Fire")
            {
                if (_primary.GetCourage() >= _primary.GetMaxCourage())
                    action = 2;
                else if (_primary.GetCourage() >= _primary.GetMinCourage())
                    action = 1;
            }

            if (_primary.GetType() == "Water" || _primary.GetType() == "Earth")
                if (_primary.GetCourage() >= _primary.GetMaxCourage())
                    action = 1;
                else if (_primary.GetCourage() >= _primary.GetMinCourage())
                    action = 2;

            if (action == 1)
                damage = _primary.GetAttack();
            else if (action == 2)
                damage = _primary.UseSecondary();  
        }
        return damage;
    }
}