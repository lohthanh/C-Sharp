public class Attack
{
    public string Name { get; set; }
    public int DamageAmount { get; set; }

    public override string ToString()
    {
        return Name + ", " + DamageAmount;
    }

    public Attack(string name, int damageAmount)
    {
        Name = name;
        DamageAmount = damageAmount;
    }
}