public class Earth:Pokie
{
    bool _usedSecondary;

    public Earth(string name, string type, int health, int attack, int secondary, int attackCourage, int secondaryCourage):base(name, type, health, attack, secondary, attackCourage, secondaryCourage)
    {
    }

    public override void DisplayStats()
    {
        base.DisplayStats();
        Console.WriteLine($"Stone Wall: {_pokieName} will take {_secondary} less damage if your opponent attacks. Need {_secondaryCourage} courage\n");
    }

    public override int UseSecondary()
    {
        if (_courageCount >= _secondaryCourage)
        {
            _usedSecondary = true;
        }

        else 
        {
            Console.WriteLine($"{_pokieName} doesn't have enough Courage!");
        }

        return 0;
    }

    public override int TakeDamage(int damage)
    {
        _totalHealth = base.TakeDamage(damage);
        if (_usedSecondary)
        {
            _totalHealth += _secondary;
            if (_totalHealth > _health)
            {
                _totalHealth = _health;
            }
            _usedSecondary = false;
        }
        return _totalHealth;
    }
}