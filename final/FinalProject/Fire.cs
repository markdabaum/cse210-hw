using System.Security;

public class Fire:Pokie
{
    bool _usedSecondary;

    public Fire(string name, string type, int health, int attack, int secondary, int attackCourage, int secondaryCourage):base(name, type, health, attack, secondary, attackCourage, secondaryCourage)
    {
    }

    public override void DisplayStats()
    {
        base.DisplayStats();
        Console.WriteLine($"Set Fire: {_secondary} additional damage will be done to your opponents primary Pokie ({_secondaryCourage} Courage)\n");  
    }

    public override int UseSecondary()
    {
        if (_courageCount >= _secondaryCourage)
            _usedSecondary = true;
        else{
            Console.WriteLine($"{_pokieName} doesn't have enough Courage!");
        }
        int attack = GetAttack();
        return attack;
    }

    public override int GetAttack()
    {
        int attack = base.GetAttack();
        if (attack == 0)
            return 0;
        else
        {
            if (_usedSecondary)
            {
                attack += _secondary;
                _usedSecondary = false;
            }
            return attack;
        }
    }
}