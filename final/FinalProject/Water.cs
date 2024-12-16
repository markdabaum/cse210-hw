public class Water:Pokie
{
    public Water(string name, string type, int health, int attack, int secondary, int attackCourage, int secondaryCourage):base(name, type, health, attack, secondary, attackCourage, secondaryCourage)
    {
    }

    public override void DisplayStats()
    {
        base.DisplayStats();
        Console.WriteLine($"Water Bath: Heal {_secondary} to {_pokieName}. ({_secondaryCourage} Courage)");
        Console.WriteLine("Weak to Earth Pokies\n");
    }

    public override int UseSecondary()
    {
        if (_courageCount >= _secondaryCourage){
            _totalHealth += _secondary;
            if (_totalHealth > _health)
                _totalHealth = _health;
        }

        else
        {
            Console.WriteLine($"{_pokieName} doens't have enough Courage!");
        }
        return 0;
    }
}