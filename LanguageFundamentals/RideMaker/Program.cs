Vehicle HouseCar = new Vehicle("Mazda", 4, "Blue", true);
Vehicle Bus = new Vehicle("Hound", 25, "White", true);
Vehicle MyBike = new Vehicle("Bike", 1, "Black", false);
Vehicle MiniCoup = new Vehicle("Coup", "Red");

List<Vehicle> VehicleList = new List<Vehicle>();

VehicleList.Add(HouseCar);
VehicleList.Add(Bus);
VehicleList.Add(MyBike);
VehicleList.Add(MiniCoup);

// foreach (Vehicle car in VehicleList)
// {     
//     car.ShowInfo();
// }

MiniCoup.Travel(100);
MiniCoup.ShowInfo();
MiniCoup.Travel(50);