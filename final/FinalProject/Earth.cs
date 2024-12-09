public class Earth:Pokie
{
    int _defenceValue;
    bool _usedSecondary;

    public Earth(string name, string type, int health, int attack, int attackCourage, int secondaryCourage, int defence):base(name, type, health, attack, attackCourage, secondaryCourage)
    {
        _defenceValue = defence;
    }
}