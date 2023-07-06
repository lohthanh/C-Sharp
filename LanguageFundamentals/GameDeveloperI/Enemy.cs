class Enemy
{
    public string Name {get;set;}
    public int Health {get;set;}
    public List<Attack> AttackList {get;set;}

    public Enemy(string name) 
    {
        Name = name;
        Health = 100;
        AttackList = new List<Attack>();
    }

    public void RandomAttack()
    {
        Random rand = new Random();
        int randomAttackIndex = rand.Next(0, AttackList.Count);
        Attack randomAttack = AttackList[randomAttackIndex];
        Console.WriteLine($"{Name} attacked with {randomAttack.Name}!");
    }
}