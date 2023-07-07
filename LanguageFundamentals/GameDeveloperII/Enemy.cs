public class Enemy
{
    public string Name {get;set;}
    public int Health {get;set;}

    public int _MaxHealth {get;set;}
    public List<Attack> AttackList {get;set;}

    public Enemy(string name, int health = 100) 
    {
        Name = name;
        Health = health;
        _MaxHealth = health;
        AttackList = new List<Attack>();
    }

    public Attack RandomAttack()
    {
        Random rand = new Random();
        int randomAttackIndex = rand.Next(0, AttackList.Count);
        Attack randomAttack = AttackList[randomAttackIndex];
        return randomAttack;
        // Console.WriteLine($"{Name} attacked with {randomAttack.Name}!");
    }

    public virtual void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        Target.Health -= ChosenAttack.DamageAmount;
        Console.WriteLine($"{Name} attacks {Target.Name} with {ChosenAttack.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target.Health}!");
    }
}