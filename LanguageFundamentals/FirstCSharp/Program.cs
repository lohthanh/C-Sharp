// string name = "Leliana";
// int age = 4;
// bool female = true;
// double weight = 32.5;
// char grades = 'A';

// Console.WriteLine($"Hello, my name is {name}. I am {age} years old. It is {female}, I am female. I weigh {weight}lbs and I always get an {grades} for class.");

// Write a conditional in which you will only allow customers greater than or equal to 42 inches and shorter than 78 inches to get on a roller coaster.

// int height = 80;

// if (height >= 42 && height < 78) {
//     Console.WriteLine("You may ride the roller coaster.");
// } else {
//     Console.WriteLine("Sorry, you can't ride.");
// }

// Write a conditional in which you check with a boolean whether an order has been completed. Print out "Order complete!" if so 
// and "Order is still in process" if not.
// bool order = false;

// if (order == true) {
//     Console.WriteLine("Order complete!");
// } else {
//     Console.WriteLine("Order is still in process");
// }

// Write a conditional in which you order your favorite drink (you pick the drink!). If you receive the wrong drink, 
// print out "I ordered [insert your favorite drink here]."
// Bonus: Add to the above condition that if you receive the right drink but it is not in the right temperature range (hot or cold depending on your drink) 
// then you send it back.

// string drink = "soda";
// int temp = 78;

// if (drink == "bubble tea" && temp < 100) {
//     Console.WriteLine("Thank you");
// } else {
//     Console.WriteLine("I'm returning this drink.");
// }

// for (int i = 1; i <= 10; i++) {
//     Console.WriteLine(i);
// }

// Our while loop
// int i = 1;
// while(i <=10)
// {
//     Console.WriteLine(i);
//     i++;
// }

// Write a for loop that prints all numbers from 1 to 50 (50 inclusive).
// for (int i = 1; i <= 50; i++)
// {
//     Console.WriteLine(i);
// }

// Write a for loop that prints all even numbers between 1 and 50 (50 exclusive, which means the last number we should see is 48).
// There are a couple of ways you can do this! Try to figure them both out:
// First by modifying the iterator
// Second by adding a conditional statement in the loop

// for (int i = 2; i < 50; i += 2)
// {
//     Console.WriteLine(i);
// }

// for (int i = 1; i < 50; i++)
// {
//     if (i % 2 == 0) {
//         Console.WriteLine(i);
//     }
// }

// In your first loop that goes from 1 to 50, add a condition that prints "+10" for every 10 iterations (you should see +10 in the terminal 5 times) -- 
// you may need to think about how to do this one for a bit!

// for (int i = 1; i <= 50; i++)
// {
//     if (i % 10 == 0) {
//         Console.WriteLine("+10");
//     }
// }

// Write a loop that decrements by threes from 99 to 0 and prints the values (all numbers you see should be divisible by 3 if you do this right)

// for (int i = 99; i >= 0; i-= 3)
// {
//     Console.WriteLine(i);
// }

Random rand = new Random();

// for (int i = 1; i <= 10; i++)
// {
//     Console.WriteLine(rand.Next(2,9));
// }

// Combine what you've learned so far! Write a loop that runs 15 times and gets a random number between 1 and 10 (10 inclusive) each time. 
// However, you should only print the value if it is equal to 1 OR 7. Run this code several times and see how many times you get results on each run. 
// Tip: Break this problem into multiple parts, first get ALL values to print, then limit it to only printing the values you need.

// for (int i = 1; i <= 15; i++)
// {   
//    if (rand.Next(11) == 1) {
//     Console.WriteLine("I rolled a 1");
//    }
//    if (rand.Next(11) == 7) {
//     Console.WriteLine("I rolled a 7");
//    }
// }

//Arrays

// Create an array of integers that will hold 8 values. (Do not fill in the values, just create 8 slots.)

int[] myArray = new int[8];

// Place the number 17 in the third spot of your array. (Think carefully about the index number you need to make this happen!)
myArray[2] = 17;

// Try to place the word "Hello" in the fifth spot. What happens? Comment your code explaining what happened.
// myArray[4] = "Hello"; cannot explicitly convert to type string error

// Loop through your array and print out the values.
// for (int i = 0; i < myArray.Length; i++)
// {
//    Console.WriteLine(i);
// }

// foreach(int num in myArray) {
//    Console.WriteLine(num);
// }

//Lists

List<string> myGroceryList = new List<string>();
myGroceryList.Add("tomatoes");
myGroceryList.Add("noodles");
myGroceryList.Add("rice");
myGroceryList.Add("cookies");
myGroceryList.Add("cakes");
myGroceryList.Add("orange juice");

// for (int i = 0; i < myGroceryList.Count; i++)
// {
//    Console.WriteLine(myGroceryList[i]);
// }

// myGroceryList.Remove("cookies");
// myGroceryList.RemoveAt(0);
// foreach(string item in myGroceryList) {
//    Console.WriteLine(item);
// }

// Write some code that gives you a random item from your grocery List. 
// (Tip: remember Random is a built-in feature we have and think about how to get a random number within the Lists' range)

// int randomGrocery = rand.Next(myGroceryList.Count);
// Console.WriteLine(randomGrocery);

//Dictionaries

Dictionary<string, int> MyDictionary = new Dictionary<string, int>();
MyDictionary.Add("Anime Watched", 1234);
MyDictionary.Add("Games Played", 55);
MyDictionary.Add("Games Owned", 27);
MyDictionary.Add("Leli's Age", 4);
MyDictionary.Remove("Leli's Age");
MyDictionary.Clear();

foreach (KeyValuePair<string, int> item in MyDictionary)
{
      Console.WriteLine($"{item.Key}: {item.Value}");
}
// foreach (KeyValuePair<string, int> item in MyDictionary)
// {
//    if(item.Value > 5) {
//       Console.WriteLine($"{item.Key}: {item.Value}");
//    }
// }

// MyDictionary.Add("Games Owned", 23);

// foreach (KeyValuePair<string, int> item in MyDictionary)
// {  
//    Console.WriteLine(item);
// }
//error, an item with the same key already exists
