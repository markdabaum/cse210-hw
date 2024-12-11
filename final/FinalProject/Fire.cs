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
        Console.WriteLine($"Set Fire: {_secondary} additional damage will be done to your opponents primary Pokie. {_pokieName} will lose 2 courage ({_secondaryCourage} Courage)");
        Console.WriteLine($"Weak to Water Pokies\n");   
    }
}