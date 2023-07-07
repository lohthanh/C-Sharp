//parent class
public class Drink
{
    public string Name;
    public string Color;
    public string Temperature;
    public bool IsCarbonated;
    public int Calories;

    public Drink (string name, string color, string temperature, bool isCarbonated, int calories)
    {
        Name = name;
        Color = color;
        Temperature = temperature;
        IsCarbonated = isCarbonated;
        Calories = calories;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Temperature: {Temperature}");
        Console.WriteLine($"Is it carbonated? - {IsCarbonated}");
        Console.WriteLine($"Calories: {Calories}");
    }
}