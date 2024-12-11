public class Water:Pokie
{
    public Water(string name, string type, int health, int attack, int secondary, int attackCourage, int secondaryCourage):base(name, type, health, attack, secondary, attackCourage, secondaryCourage)
    {
    }

    public override void DisplayStats()
    {
        base.DisplayStats();
        Console.WriteLine($"Water Bath: In addition to {_pokieName}'s basic attack, Heal {_secondary} to {_pokieName}. ({_secondaryCourage} Courage)");
        Console.WriteLine("Weak to Earth Pokies\n");
    }
}