//child class

public class Soda : Drink
{
    public bool IsDiet;

    public Soda(string name, string color, string temperature, int calories, bool isDiet) : base (name, color, temperature, true, calories)
    {
        IsDiet = isDiet;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Diet? - {IsDiet}");
    }
}