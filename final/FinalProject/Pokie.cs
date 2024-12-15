public class Pokie
{
    protected string _pokieName;
    private string _type;
    private int _health;
    private int _totalHealth;
    private int _attack;
    protected int _secondary;
    private int _courageCount;
    private int _attackCourage;
    protected int _secondaryCourage;

    public Pokie(string type, string name, int health, int attack, int secondary, int attackCourage, int secondaryCourage)
    {
        _pokieName = name;
        _type = type;
        _health = health;
        _totalHealth = health;
        _attack = attack;
        _secondary = secondary;
        _courageCount = 0;
        _attackCourage = attackCourage;
        _secondaryCourage = secondaryCourage;
    }

    public virtual void DisplayStats()
    {
        Console.WriteLine($"{_pokieName}: ({_totalHealth}/{_health}) {_courageCount} Courage");
        Console.WriteLine($"Basic Attack: {_attack} ({_attackCourage} Courage)");
    }

    public string GetType()
    {
        return _type;
    }

    public void ReceiveCourage()
    {
        _courageCount++;
    }

}