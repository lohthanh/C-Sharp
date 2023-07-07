public class MagicCaster : Enemy
{
    public MagicCaster(string name) : base(name, 80)
    {}

    public void Heal(Enemy Target)
    {
        // heals a targeted Enemy character for 40 health 
        // and displays the new health at the end
        if(Target.Health < Target._MaxHealth - 40)
        {
            Target.Health += 40;
        } else {
            Target.Health = Target._MaxHealth;
        }
        Console.WriteLine($"Healed {Target.Name}, health returned to {Target.Health}");
    }
}