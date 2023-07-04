//Three Basic Arrays

// Create an integer array with the values 0 through 9 inside.
int[] MyNumberArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// Create a string array with the names "Tim", "Martin", "Nikki", and "Sara".
string[] MyStringArray = { "Tim", "Martin", "Nikki", "Sara" };

// Create a boolean array of length 10. Then fill it with alternating true/false values, starting with true. 
// (Tip: do this using logic! Do not hard-code the values in!)
bool[] MyBooleanArray = new bool[10];
// MyBooleanArray[0] = true;
// MyBooleanArray[1] = false;
// MyBooleanArray[2] = true;
// MyBooleanArray[3] = false;
// MyBooleanArray[4] = true;
// MyBooleanArray[5] = false;
// MyBooleanArray[6] = true;
// MyBooleanArray[7] = false;
// MyBooleanArray[8] = true;
// MyBooleanArray[9] = false;

for (int i = 0; i < MyBooleanArray.Length; i++)
{
    MyBooleanArray[i] = i % 2 == 0;
    // Console.WriteLine(MyBooleanArray[i]);
}

//List of Flavors

// Create a string List of ice cream flavors that holds at least 5 different flavors. (Feel free to add more than 5!)
List<string> FlavorList = new List<string>() { "Chocolate", "Mint", "Strawberry", "Vanilla", "Butter Pecan", "Coffee" };

// Output the length of the List after you added the flavors.
// Console.WriteLine(FlavorList.Count);

// Output the third flavor in the List.
// Console.WriteLine(FlavorList[2]);

// //Now remove the third flavor using its index location.
FlavorList.RemoveAt(2);

//Output the length of the List again. It should now be one fewer.
// Console.WriteLine(FlavorList.Count);

// //User Dictionary

// Create a dictionary that will store string keys and string values.
Dictionary<string, string> MyDictionary = new Dictionary<string, string>();

// Add key/value pairs to the dictionary where:
// Each key is a name from your names array (this can be done by hand or using logic)
// Each value is a randomly selected flavor from your flavors List (remember Random from earlier?)
Random rand = new Random();

// Console.WriteLine(randomFlavor);
foreach (string name in MyStringArray)
{
    int randomIndex = rand.Next(FlavorList.Count);
    string randomFlavor = FlavorList[randomIndex];
    MyDictionary.Add(name, randomFlavor);
}

// Loop through the dictionary and print out each user's name and their associated ice cream flavor.
foreach (KeyValuePair<string, string> entry in MyDictionary)
{
    Console.WriteLine($"{entry.Key} favorite flavor is {entry.Value}");
}