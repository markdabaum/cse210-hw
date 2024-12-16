using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

public class Pokie
{
    protected string _pokieName;
    private string _type;
    protected int _health;
    protected int _totalHealth;
    private int _attack;
    protected int _secondary;
    protected int _courageCount;
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

    public string GetName()
    {
        return _pokieName;
    }

    public int GetCourage()
    {
        return _courageCount;
    }

    public int GetMaxCourage()
    {
        if (_attackCourage > _secondaryCourage)
            return _attackCourage;
        else
            return _secondaryCourage;
    }

    public int GetMinCourage()
    {
        if (_attackCourage < _secondaryCourage)
            return _attackCourage;
        else 
            return _secondaryCourage;
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

    public virtual int UseSecondary(){return 0;}

    public virtual int GetAttack()
    {
        if (_courageCount >= _attackCourage)
        {
            return _attack;
        }

        else
        {
            Console.WriteLine($"{_pokieName} Doesn't have enough Courage!");
            Thread.Sleep(1000);
            return 0;
        }
    }

    public virtual int TakeDamage(int damage)
    {
        _totalHealth -= damage;
        return _totalHealth;
    }

}