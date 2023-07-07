//Child class

public class Boba : Drink
{
    public string Toppings;
    public bool HasBoba;
    public Boba(string toppings, bool hasBoba, string name, string color,
    string temperature, bool isCarbonated, int calories) : base(name, color, temperature, isCarbonated, calories)
    {
        Toppings = toppings;
        HasBoba = hasBoba;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Toppings: {Toppings}");
        Console.WriteLine($"Is boba included? - {HasBoba}");
    }
}