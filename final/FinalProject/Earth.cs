public class Earth:Pokie
{
    bool _usedSecondary;

    public Earth(string name, string type, int health, int attack, int secondary, int attackCourage, int secondaryCourage):base(name, type, health, attack, secondary, attackCourage, secondaryCourage)
    {
    }

    public override void DisplayStats()
    {
        base.DisplayStats();
        Console.WriteLine($"Stone Wall: {_pokieName} will take {_secondary} less damage if your opponent attacks. Need {_secondaryCourage} courage");
        Console.WriteLine("Weak to Fire Pokies\n");
    }
}