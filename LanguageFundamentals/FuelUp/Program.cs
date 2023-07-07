Car Toyota = new Car("Prius", 4, "Blue", "Electric");
Horse Horse = new Horse("Black Beauty", 1, "Black", "Hay");
Bicycle Bike = new Bicycle("Roller", "Purple");

Toyota.ShowInfo();
Toyota.GiveFuel(10);

Bike.ShowInfo();

// Vehicle vehicle = new Vehicle("BMW", 4, "Purple", true);
// vehicle.ShowInfo();
// Error - Can not make an instance of the abstract type or interface Vehicle
List<Vehicle> AllVehicles = new List<Vehicle>();
AllVehicles.Add(Toyota);
AllVehicles.Add(Horse);
AllVehicles.Add(Bike);

for (int i = 0; i < AllVehicles.Count; i++)
{
    Console.WriteLine(AllVehicles[i].Name);
}

List<INeedFuel> NeedFuel = new List<INeedFuel>();

foreach(Vehicle a in AllVehicles)
{
    if (a is INeedFuel)
    {
        NeedFuel.Add((INeedFuel)a);
        // Console.WriteLine(a);
    }
}

// Take your finished INeedFuel List, loop through it, and give each item 10 units of fuel
foreach (INeedFuel a in NeedFuel)
{
    a.GiveFuel(10);
}

for (int i = 0; i < NeedFuel.Count; i++)
{
    Console.WriteLine($"{NeedFuel[i]}, {NeedFuel[i].FuelTotal}");
}