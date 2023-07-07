Boba MilkTea = new Boba("pudding", true, "QQ Happy Family", "dark brown", "iced cold", false, 65);
Coffee Coffee = new Coffee("Bourbon", "Medium", "French Roast", "black", "hot", false, 75);
Soda Coke = new Soda("Coke", "black", "cold", 95, false);

// MilkTea.ShowInfo();
// Coke.ShowInfo();
// Coffee.ShowInfo();

List<Drink> AllBeverages = new List<Drink>();
AllBeverages.Add(MilkTea);
AllBeverages.Add(Coffee);
AllBeverages.Add(Coke);

foreach(Drink drink in AllBeverages)
{
    drink.ShowInfo();
}

// Coffee MyDrink = new Soda("name", "color", "cold", 85, true);
//Error - Cannot implicitly covert type 'Soda' to 'Coffee'. Meaning it's 2 different classes, 
// they are not the same even though they have the same parent.