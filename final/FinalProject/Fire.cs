using System.Security;

public class Fire:Pokie
{
    int _bonusValue;
    bool _usedSecondary;

    public Fire(string name, string type, int health, int attack, int secondary, int attackCourage, int secondaryCourage, int bonus):base(name, type, health, attack, attackCourage, secondaryCourage)
    {
        _secondary = secondary;
        _bonusValue = bonus;
    }

    public override void DisplayStats()
    {
        base.DisplayStats();
        Console.WriteLine($"Set Fire: {_secondary} additional damage will be done to your opponents primary Pokie. {_pokieName} will lose 2 courage ({_secondaryCourage} Courage)");
        Console.WriteLine($"Weak to Water Pokies");   
    }
}