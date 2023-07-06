class Attack
{
    public string Name { get; set; }
    //DamageAmount (i.e. a fireball will do 20 damage, keep the damage range between 5 and 25)
    private int _damageAmount;
    public int DamageAmount
    {
        get { return _damageAmount; }
        set
        {
            if (value >=5 && value <=25)
            {
                _damageAmount = value;
            } else {
                _damageAmount = 5;
            };
        }
    }

    public override string ToString()
    {
        return Name + " , " + DamageAmount;
    }

    public Attack(string name, int damageAmount)
    {
        Name = name;
        DamageAmount = damageAmount;
    }
}