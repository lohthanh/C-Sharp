//Coin Flip
// Write a function that returns "heads" or "tails" depending on the result you get.
// If you don't know where to start, consider the following prompts:
// How many results can you get when you flip a coin?
// How can we write code that produces a single, random result from our pool of options?
// What happens after the coin lands? (i.e. How do you determine what the result was and convey that to your user?)

// static void CoinFlip() 
// {
//     Random rand = new Random();
//     int randomSide = rand.Next(2);
//     if(randomSide == 1)
//     {
//         Console.WriteLine("Heads");
//     } else {
//         Console.WriteLine("Tails");
//     }
// }

// CoinFlip();

//Dice Roll
// Consider the following:
// How many sides is your die? (We recommend you start with a standard 6-sided die but feel free to start wherever you like!)
// How many results can we get based on how many sides there are? Write down all possible results if needed.
// Tip: Make sure to return the value rolled at the end.
// Bonus: Can you rewrite your function to accept a parameter for the number of sides so you can roll any number-sided die?
// static int DiceRoll(int sides)
// {
//     Random rand = new Random();
//     int rollDice = rand.Next(1, sides);
//     return rollDice;
// }
// Console.WriteLine(DiceRoll(12));

//Stat Roll
// write a new function that will roll your dice 4 times and returns a List of those 4 results. You can write your function to hard-code 4 dice rolls.
// Consider the following:
// How do you make a function run repeatedly?
// How can we see the results of our rolls? (What happens when you try to Console.WriteLine a List?)
// Bonus: Write your function to roll any number of times you would like.
// Bonus: After finishing your rolls, print the largest value you rolled.
// static int DiceRoll(int times)
// {
//     List<int> Results = new List<int>();
//     for (int i = 1; i <= times; i++)
//     {
//     Random rand = new Random();
//     int rollDice = rand.Next(1, 7);
//     Results.Add(rollDice);    
//     }
//     foreach(int index in Results)
//     {
//         Console.WriteLine(index);
//     }
//     int max = Results.Max();
//     Console.WriteLine("Max number: " + max);
//     return max;
// }
// DiceRoll(6);

//Roll Until...
// Write a new function that will roll your 6-sided die until you land on a certain result and tracks how many rolls occurred until it lands on the given number. 
// For example, you could tell your code to keep rolling until your 6-sided die rolls the number 2. When you land on the number, return a string that says "Rolled a {number} after {count} tries". 
// Tip: Do not hard-code the number you're looking for. Be able to accept any number.
// Consider the following:
// Do we know how many times our die will roll before it lands on the number we asked for? If not, how will this influence the logical options we have?
// What would happen if we ask for a number that is not on our die? (i.e. What happens if we tell our die to roll until it lands on 8 on a 6-sided die?) 
// How can we prevent or handle unwanted inputs?
static string DiceRoll(int num)
{
    Random rand = new Random();
    int dice = rand.Next(1, 7);
    int count = 0;
    if (num > sides)
    {
        return "Number is not on dice";
    }
    while (dice != num)
    {
        count++;
        dice = rand.Next(1, 7);
    }

    return $"Rolled a {num} after {count} tries.";
}

Console.WriteLine(DiceRoll(15));