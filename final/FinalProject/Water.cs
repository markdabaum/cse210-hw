public class Water:Pokie
{
    int _healValue;

    public Water(string name, string type, int health, int attack, int attackCourage, int secondaryCourage, int heal):base(name, type, health, attack, attackCourage, secondaryCourage)
    {
        _healValue = heal;
    }

    public override void DisplayStats()
    {
        base.DisplayStats();
        Console.WriteLine($"Water Bath: In addition to {_pokieName}'s basic attack, Heal {_secondary} to {_pokieName}. ({_secondaryCourage} Courage)");
        Console.WriteLine("Weak to Earth Pokies");
    }
}