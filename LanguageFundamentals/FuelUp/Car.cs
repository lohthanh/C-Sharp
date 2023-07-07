public class Car : Vehicle, INeedFuel
{
    public string FuelType { get; set; }
    public int FuelTotal { get; set; }

    public Car(string name, int numOfPassengers, string color, string fuelType) : base(name, numOfPassengers, color, true)
    {
        FuelType = fuelType;
        FuelTotal = 10;
    }

    public void GiveFuel(int Amount)
    {
        FuelTotal += Amount;
        Console.WriteLine($"Fuel {Name} with {FuelType} of {Amount} to make it total {FuelTotal}.");
    }

}