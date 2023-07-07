public class MeleeFighter : Enemy 
{
    public MeleeFighter(string name) : base(name, 120)
    {}

    public void Rage(Enemy Target)
    {
        Attack a = RandomAttack();
        a.DamageAmount += 10;
        base.PerformAttack(Target, a);
        a.DamageAmount -= 10;
    }

}