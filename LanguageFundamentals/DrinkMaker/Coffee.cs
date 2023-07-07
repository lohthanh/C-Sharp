//child class

public class Coffee : Drink
{
    public string TypeOfBean;
    public string RoastLevel;
    public Coffee(string typeOfBean, string roastLevel, string name, string color, string temperature, bool isCarbonated, int calories) : base(name, color, temperature, isCarbonated, calories)
    {
        TypeOfBean = typeOfBean;
        RoastLevel = roastLevel;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Beans: {TypeOfBean}");
        Console.WriteLine($"Roast: {RoastLevel}");
    }
}