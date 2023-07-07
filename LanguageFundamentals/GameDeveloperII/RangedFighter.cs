public class RangedFighter : Enemy 
{
    public int Distance;
    public RangedFighter(string name) : base(name)
    {
        Distance = 5;
    }

    public void Dash(Enemy Target)
    {
        Distance = 20;
    }

    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if(Distance < 10) 
        {
            Dash(Target);
            Console.WriteLine($"Too close to target, {Distance}");
        } else 
        {
            base.PerformAttack(Target, ChosenAttack);
        }
    }

}