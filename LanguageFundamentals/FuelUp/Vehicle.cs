public abstract class Vehicle
{
    public string Name;
    public int NumOfPassengers;
    public string Color;
    public bool HasEngine;
    public int DistanceTraveled;

    public Vehicle(string name, int numOfPassengers, string color, bool hasEngine)
    {   
        Name = name;
        NumOfPassengers = numOfPassengers;
        Color = color;
        HasEngine = hasEngine;
        DistanceTraveled = 0;
    }
    public Vehicle(string name, string color)
    {   
        Name = name;
        Color = color;
        NumOfPassengers = 4;
        HasEngine = true;
        DistanceTraveled = 0;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Number of passengers: {NumOfPassengers}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Has engine: {HasEngine}");
        Console.WriteLine($"Distance traveled: {DistanceTraveled}");
    }

    public void Travel(int distance)
    {
        DistanceTraveled += distance;
        Console.WriteLine($"Total distance traveled: {DistanceTraveled}");
    }
}